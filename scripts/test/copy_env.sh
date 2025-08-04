#!/bin/bash

# Copy default .env if .env.local does not already exist for all services:
cp -n docker/test/adminer/.env docker/test/adminer/.env.local
cp -n docker/test/aspnet/.env docker/test/aspnet/.env.local
cp -n docker/test/mssql/.env docker/test/mssql/.env.local
cp -n docker/test/vue/.env docker/test/vue/.env.local

cp -n docker/test/nginx/wrychain-ssl.conf docker/test/nginx/wrychain-ssl.conf.local
cp -n docker/test/nginx/wrychain.conf docker/test/nginx/wrychain.conf.local
