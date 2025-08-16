FROM redis:7.2-alpine

COPY ./docker/development/redis/redis.conf.local /usr/local/etc/redis/redis.conf

ENTRYPOINT cat /usr/local/etc/redis/redis.conf && redis-server /usr/local/etc/redis/redis.conf