FROM redis:7.2-alpine

COPY ./docker/test/redis/redis.conf /usr/local/etc/redis/redis.conf

ENTRYPOINT cat /usr/local/etc/redis/redis.conf && redis-server /usr/local/etc/redis/redis.conf