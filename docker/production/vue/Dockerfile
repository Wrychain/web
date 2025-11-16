# build stage
FROM node:lts-alpine AS build-stage
WORKDIR /wrychain
COPY ./src/frontend/package.json .
COPY ./src/frontend/package-lock.json .
RUN npm install
COPY ./src/frontend/ .
RUN npm run build

# production stage
FROM nginx:stable-alpine AS production-stage
RUN rm /etc/nginx/conf.d/default.conf
COPY ./docker/production/vue/nginx.conf.local /etc/nginx/conf.d/nginx.conf
COPY --from=build-stage /wrychain/dist /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
