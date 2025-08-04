FROM node:24-bookworm-slim

RUN apt update
RUN apt upgrade -y
RUN npm install -g @vue/cli

WORKDIR /wrychain

ENTRYPOINT npm update && npm run test:unit
