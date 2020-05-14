# Command and Query Responsibility Segregation (CQRS)

What are **commands**?

-   update state
-   perform an action
-   should not return a value

What are **queries**?

-   Read data
-   answer a question
-   doesn't modify state
-   should return a value

## Single Database Implementation of CQRS

Commands use the entities defined inside the DOMAIN layer.
Queries query directly against the database.

READ and WRITE queries touch a single DB, pretty straightforward.

## Multiple Database Implementation of CQRS

READ queries will run against the READ DATABASE.

WRITE queries will run against the WRITE DATABASE.

Why the separation of query operations and databases?

-   Optimization, WRITE queries might need more server resources to perform complex update. And READ queries can operate with less resources and may have more load balancers for frequency.
