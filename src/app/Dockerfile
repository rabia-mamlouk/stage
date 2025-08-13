# Development Dockerfile for Angular application
FROM node:18.10.0
 
# Set working directory
WORKDIR /app
 
 
# Copy package.json and package-lock.json
COPY package.json ./
 
# Install Angular CLI globally
RUN npm install
 
 
# Copy source code
COPY . .
 
# Expose development server port
EXPOSE 3000
 
# Start development server
CMD ["npx","ng", "serve", "--host", "0.0.0.0"]