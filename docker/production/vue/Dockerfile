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
COPY --from=build-stage /wrychain/dist /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
