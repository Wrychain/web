#!/bin/bash

# Copy default .env if .env.local does not already exist for all services:
cp -n docker/development/adminer/.env docker/development/adminer/.env.local
cp -n docker/development/aspnet/.env docker/development/aspnet/.env.local
cp -n docker/development/mssql/.env docker/development/mssql/.env.local
cp -n docker/development/vue/.env docker/development/vue/.env.local

cp -n docker/development/nginx/wrychain-ssl.conf docker/development/nginx/wrychain-ssl.conf.local
cp -n docker/development/nginx/wrychain.conf docker/development/nginx/wrychain.conf.local
