# Clean Architecture Layers

Entities = Domain Project
Use Cases = Application Project
Controllers, Gateways, Presenters = API Project
Devices, Db, Web, UI, External Interface = Client Project

## Summary of Layers

### Entities

An entity can be an object with methods, or it can be a set of data structures and functions. It doesn’t matter so long as the entities could be used by many different applications in the enterprise. They encapsulate the most general and high-level rules. They are the least likely to change when something external changes.

Examples: Activity

### Use Cases

The software in this layer contains application specific business rules. It encapsulates and implements all of the use cases of the system. These use cases orchestrate the flow of data to and from the entities, and direct those entities to use their enterprise wide business rules to achieve the goals of the use case.

Examples: Application

### Controllers, Gateways, Presenters

Examples: API

### Devices, DB, Web, UI

---

### Dependencies

The Clean Architecture pattern states, "All dependencies should point inward. Meaning that an inner layer can't reference things outside of it.
