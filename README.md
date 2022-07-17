# ElectroShopApi

![logo](https://user-images.githubusercontent.com/8405055/179391281-3478a798-2f1a-4d55-b994-fa3574ab0fd8.png)

The minimal API for online shop with pre-seeded values. The shop allows to order different electronic devices, taking into consideration various tax rates.

**Try it -> https://electroshopapi.herokuapp.com/swagger**

## Motivation

After working with many shop APIs on frontend side (mainly mobile), I had some insights how efficient purchase proces should be designed. I decided to try something new and try my hand on the other side of the fence :)

## Structure

To make this backend more extensible in the further future, project is divided into three parts:

* **ElectroShop** - independent module with business logic. The UseCases operates on delivered data (collections), and not repository reference
* **ElectroShopDB** - configuration of database. It is ready to accept any DB engine, but for convenience operates only on InMemoryDatabase. The needed migrations and data seeding is carried out during initialization
* **ElectroShopApi** - startup module for program, uses informations from domain and database. It maps tables to models and exposes clean API in Swagger

## Domain

* Cart
  * Cart
* CartSummary
  * CartSummary
  * SummaryProduct
* Order
  * Order
* Payment
  * Payment
  * PaymentOption
    * PaymentOptionType
  * PaymentRequirment
  * PaymentStatus
* Product
  * Product
  * ProductCategory
  * Manufacturer
* Tax
  * TaxRate
* User
  * User
  
## Features
* Modules
* Service injection
* CORS configuration
* Swagger
* Routing and auto controllers mapping
* Enum to JSON conversion
* Context per Table distinction
* Data seeding
* EF Core and LINQ
* InMemoryDatabase
* Extensions
