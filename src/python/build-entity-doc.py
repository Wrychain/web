import os
import re

PROJECT_PREFIX = "/wrychain/backend/"
ENTITY_DIRECTORY = f"{PROJECT_PREFIX}Wrychain.DAL/Entity"
DATA = {}
DEBUG = True

def debug(msg=""):
    if DEBUG:
        print(msg)

# Create a list recursively of all files within entity directory.
files_list = []
for root, dirs, files in os.walk(ENTITY_DIRECTORY):
    for file in files:
        full_path = os.path.join(root, file)
        scope = full_path.replace("/" + file, "").replace(PROJECT_PREFIX, "").replace("/", ".")

        if scope not in DATA:
            DATA[scope] = {}

        DATA[scope][file] = {}
        DATA[scope][file]["path"] = full_path
        DATA[scope][file]["words"] = []
        DATA[scope][file]["references"] = []

# Iterate and process the data.
for scope in DATA:
    for file in DATA[scope]:
        path = DATA[scope][file]["path"]
        filename = file.replace(".cs", "")
        expected_classname = filename

        # Read the file and extract the text.
        with open(path, "r") as f:
            lines = f.readlines()
            cleaned_lines = [line.strip() for line in lines]

            # Verify namespace matches scope.
            found = False
            for line in cleaned_lines:
                if f"namespace {scope}" in line:
                    found = True
                    break
            if not found:
                print(f"Namespace mismatch for {file}")

            # Verify the class name matches the file name.
            found = False
            for line in cleaned_lines:
                if f"class {expected_classname}" in line:
                    found = True
                    break
            if not found:
                print(f"Class name mismatch for {file}")

            # Create a list of all datatypes used in the file.
            unique_words = set()
            for line in cleaned_lines:
                words = re.findall(r'\w+', line)
                if len(words) == 0:
                    continue
                unique_words.update(words)
            DATA[scope][file]["words"] = unique_words

            # Compare words against filenames to determine references.
            unique_references = set()
            for word in  unique_words:
                for scope_b in DATA:
                    for file_b in DATA[scope_b]:
                        file_b_without_extension = file_b.replace(".cs", "")
                        if word == file_b_without_extension:
                            unique_references.add(scope_b + "." + file_b_without_extension)
            # Remove self reference
            unique_references.discard(scope + "." + filename)
            DATA[scope][file]["references"] = list(unique_references)

# Verify there are not cyclic references
for scope in DATA:
    for file in DATA[scope]:
        filename = file.replace(".cs", "")
        for reference in DATA[scope][file]["references"]:
            if reference == scope + "." + filename:
                print(f"Cyclic reference found for {file}")
                print(f"\tReference: {reference}")

# Write the data to docs/entity-plan.md
OUTPUT_FILE = "/wrychain/docs/entity-plan.md"

with open(OUTPUT_FILE, "w") as f:
    for scope in DATA:
        f.write(f"# Scope: {scope}")
        f.write("\n")
        for file in DATA[scope]:
            f.write(f"> **File:** {file}")
            f.write("\n")
            f.write("\n")
            f.write(f"**Path:** {DATA[scope][file]["path"]}")
            f.write("\n")
            f.write("\n")
            # f.write(f"\t\tWords: {DATA[scope][file]["words"]}")
            # f.write("\n")
            f.write(f"**References:** {DATA[scope][file]["references"]}")
            f.write("\n")
            f.write("\n")
