import docker
import time
import json
import logging
from datetime import datetime

# Configure logging to stdout for Docker to capture
logging.basicConfig(
    level=logging.INFO,
    format='[%(asctime)s] %(message)s',
    handlers=[logging.StreamHandler()]
)

client = docker.from_env()

def collect_and_log_metrics():
    try:
        containers = client.containers.list()
        for container in containers:

            # Skip self to avoid recursive monitoring
            if container.name == 'wrychain_monitor':
                continue

            # Only monitor wrychain containers
            if not container.name.startswith('wrychain'):
                continue

            # Get stats for given container
            stats = container.stats(stream=False)

            # Extract key metrics
            cpu_percent = calculate_cpu_percent(stats)
            memory_usage = stats['memory_stats'].get('usage', 0)
            memory_limit = stats['memory_stats'].get('limit', 0)
            memory_percent = (memory_usage / memory_limit * 100) if memory_limit > 0 else 0

            metric_data = {
                # 'timestamp': datetime.utcnow().isoformat(),
                # 'container_id': container.id[:12],
                'container_name': container.name,
                'cpu_percent': cpu_percent,
                # 'memory_usage_mb': memory_usage / (1024 * 1024),
                # 'memory_limit_mb': memory_limit / (1024 * 1024),
                'memory_percent': memory_percent
            }

            metrics_output = f"{container.name} {round(cpu_percent, 2)}%CPU {round(memory_percent, 2)}%RAM"

            # Log as JSON for structured logging
            logging.info(metrics_output)

    except Exception as e:
        logging.error(f"Error collecting metrics: {e}")

def calculate_cpu_percent(stats):
    cpu_stats = stats['cpu_stats']
    precpu_stats = stats['precpu_stats']
    cpu_delta = cpu_stats['cpu_usage']['total_usage'] - precpu_stats['cpu_usage']['total_usage']
    system_delta = cpu_stats['system_cpu_usage'] - precpu_stats['system_cpu_usage']

    if system_delta > 0:
        return (cpu_delta / system_delta) * len(cpu_stats['cpu_usage']['percpu_usage']) * 100

    return 0.0

def main():
    logging.info("Starting Docker container monitoring...")
    while True:
        collect_and_log_metrics()
        time.sleep(10) # Monitor every 10 seconds

if __name__ == "__main__":
    main()
