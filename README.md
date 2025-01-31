# 🚀 Saga Pattern with MassTransit, RabbitMQ, and PostgreSQL

![MassTransit](https://raw.githubusercontent.com/MassTransit/MassTransit/master/doc/images/logo.png) ![RabbitMQ](https://upload.wikimedia.org/wikipedia/commons/7/71/RabbitMQ_logo.svg) ![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/2/29/Postgresql_elephant.svg)

This repository demonstrates the implementation of the **Saga State Machine** using **MassTransit**, **RabbitMQ**, and **PostgreSQL**. The project illustrates how to manage distributed state changes reliably with **Saga Pattern** in an event-driven architecture.

## 📌 Features

✅ Implementation of **Saga State Machine** using **MassTransit**  
✅ Event-driven state transitions stored in **PostgreSQL**  
✅ **RabbitMQ** as the message broker for asynchronous communication  
✅ Automatic state updates in the `SagaData` table  
✅ Modular and scalable architecture  

---

## 🛠️ Technologies Used

- 🟢 **MassTransit** (Saga State Machine)
- 🐰 **RabbitMQ** (Message Broker)
- 🐘 **PostgreSQL** (Database)
- 🟣 **.NET 8**
- 🐳 **Docker** (Mandatory)

---

## 📦 Installation and Execution

### 🚀 Step 1: Clone the Repository
```bash
git clone https://github.com/youruser/saga-masstransit-example.git
cd saga-masstransit-example
```

### 🐳 Step 2: Start RabbitMQ and PostgreSQL with Docker
This project requires **Docker**. Ensure Docker is installed and running. Then, start the required services:
```bash
docker-compose up -d
```
This will start **RabbitMQ** and **PostgreSQL** with the necessary configurations.

### ⚙️ Step 3: Configure MassTransit and PostgreSQL in the Project
Modify `appsettings.json` according to your setup:
```json
"RabbitMQ": {
  "Host": "localhost",
  "Username": "guest",
  "Password": "guest"
},
"ConnectionStrings": {
  "PostgreSQL": "Host=localhost;Port=5432;Database=SagaDB;Username=youruser;Password=yourpassword"
}
```

### ▶️ Step 4: Run the Services
Compile and execute the project:
```bash
dotnet run
```

---

## 📜 Workflow Example
1️⃣ **An event is triggered by calling the `newsletter` endpoint.**  
2️⃣ **MassTransit handles the event and stores the saga instance in the database.**  
3️⃣ **The state in the `SagaData` table updates automatically based on the defined transitions.**  
4️⃣ **RabbitMQ facilitates communication between different services asynchronously.**  

---

## 📖 Example of the Saga Data Table
```sql
SELECT * FROM "SagaData";
```
Example Output:
| Id | CurrentState  | CreatedAt           |
|----|-------------|---------------------|
| 1  | Submitted   | 2025-01-29 10:00:00 |
| 2  | Processed   | 2025-01-29 10:05:00 |
| 3  | Completed   | 2025-01-29 10:10:00 |

---

## 📌 Future Roadmap 🚀
- [ ] Implement **retry policies** for transient failures.  
- [ ] Add **monitoring and logging** for better observability.  
- [ ] Extend Saga with additional event-driven processes.  

---

## 👨‍💻 Contribution and Contact
If you would like to contribute or report an issue, pull requests are welcome! 🎉  
📩 Contact: [YourEmail@example.com](mailto:YourEmail@example.com)  

---

Master event-driven state management with **MassTransit, RabbitMQ, and PostgreSQL** using the **Saga Pattern**! 🟢🐰🐘
