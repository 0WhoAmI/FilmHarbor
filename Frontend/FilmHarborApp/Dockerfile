# Angular build stage
FROM node:21 AS build
WORKDIR /usr/src/app
COPY . .
RUN npm install
RUN npm run build

# Production stage
FROM nginx:stable-alpine
COPY --from=build /usr/src/app/dist /usr/share/nginx/html
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"] 
