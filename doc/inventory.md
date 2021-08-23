# Inventory

## Inventory Items
Inventory items hold two variables: type and quantity. When not picked up, they have a model that represents them in-game. Upon collision with the Robot, they get added to the robot's inventory, and destroyed.  

## Inventory
The inventory consists of a `List` of `InventoryItems` and an integer `Money`.  

## Inventory management

### Item pickup
When an item is picked up, first the already listed items get parsed if they have matching type with the currently picked up item.  
If the new `InventoryItem` is a listed type, the quantity of the listed type gets incremented. If it is not, then a new List item is created.  

## Selling an item
When an item is being sold, the appropriate price is fetched from `GameInfoHolder` and `Money` is incremented by the (price * (sold amount)).

