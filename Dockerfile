# Development Dockerfile for Angular application
FROM node:18-alpine

# Set working directory
WORKDIR /app

# Install Angular CLI globally
RUN npm install -g @angular/cli@16.2.9

# Copy package files
COPY package*.json ./

# Install all dependencies (including dev dependencies)
RUN npm install

# Copy source code
COPY . .

# Expose development server port
EXPOSE 4200

# Start development server
CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "4200"]
