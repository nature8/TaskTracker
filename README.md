# TaskTracker

# TaskTracker Microservices

## About the Project

TaskTracker is a task management application built using **C# and .NET 10** following the **Microservices Architecture**. Instead of building everything as a single application, the project is divided into independent services, making it easier to develop, deploy, and scale.

The application currently consists of two main microservices:

* **User Service** – Handles user-related operations.
* **Task Service** – Handles task management.

An **API Gateway** acts as the single entry point for all client requests, while **RabbitMQ** enables asynchronous communication between the services. The entire application is containerized using Docker and deployed to **AWS ECS (Fargate)**.

---

## Technologies Used

* C#
* .NET 10 Web API
* ASP.NET Core
* Ocelot API Gateway
* RabbitMQ
* Docker & Docker Compose
* AWS ECS (Fargate)
* Amazon ECR
* Application Load Balancer
* Amazon CloudWatch
* AWS IAM
* AWS CLI

---

## Project Structure

```text
TaskTracker-MS
│
├── Gateway
├── UserService
├── TaskService
├── Contracts
├── Docker
└── docker-compose.yml
```

---

## How It Works

When a client sends a request, it first reaches the **API Gateway**. The gateway then forwards the request to the appropriate microservice.

For communication that doesn't require an immediate response, the services use **RabbitMQ**. Instead of calling each other directly, they publish and consume messages, making the system more loosely coupled and easier to scale.

---

## Architecture

```text
                Client
                   |
                   |
        Application Load Balancer
                   |
                   |
              API Gateway
                   |
        -----------------------
        |                     |
        |                     |
   User Service         Task Service
        \                 /
         \               /
            RabbitMQ



<img width="945" height="627" alt="image" src="https://github.com/user-attachments/assets/c95bf85c-269f-4bc7-b8ad-cf15390e3bd8" />



```

---

## Features

* User Management
* Task Management
* API Gateway for request routing
* Asynchronous communication using RabbitMQ
* Dockerized microservices
* Cloud deployment on AWS ECS
* Load balancing using AWS Application Load Balancer
* CloudWatch logging

---

## Running the Project Locally

### Clone the repository

```bash
git clone https://github.com/nature8/TaskTracker.git
```

### Build the project

```bash
dotnet build
```

### Run using Docker

```bash
docker compose up --build
```

---

## AWS Deployment

The application is deployed on **Amazon ECS (Fargate)**.

Deployment includes:

* Building Docker images
* Pushing images to Amazon ECR
* Creating ECS Task Definitions
* Deploying ECS Services
* Configuring an Application Load Balancer
* Deploying RabbitMQ as a separate ECS service
* Monitoring services using Amazon CloudWatch

---

## API Endpoints

### User Service

* GET /users
* GET /users/{id}
* POST /users
* PUT /users/{id}
* DELETE /users/{id}

### Task Service

* GET /tasks
* GET /tasks/{id}
* POST /tasks
* PUT /tasks/{id}
* DELETE /tasks/{id}

---

## Future Improvements

There are several features that can be added in the future, such as:

* JWT Authentication and Authorization
* SQL Server/Amazon RDS integration
* Redis Caching
* CI/CD using GitHub Actions
* Kubernetes deployment using Amazon EKS
* Distributed tracing and monitoring

---

## What I Learned

This project helped me gain hands-on experience with:

* Designing applications using Microservices Architecture
* Building REST APIs with .NET
* Configuring an API Gateway using Ocelot
* Implementing asynchronous messaging with RabbitMQ
* Containerizing applications using Docker
* Deploying microservices on AWS ECS
* Managing cloud resources using the AWS CLI

---

## Author

**Prakruti Tailor**


This project was developed as a learning project to understand modern backend development, microservices, containerization, messaging, and cloud deployment using AWS.
