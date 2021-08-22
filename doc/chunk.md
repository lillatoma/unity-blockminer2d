# Chunk generation
## What are chunks?
Chunks are a set of objects that are very closely related to each other in terms of world position.  
For example, in this project, chunks are 16 blocks wide and 80 blocks tall set of blocks.  

## How are chunks generated?
There is a left and right invisible object next to the most left, and most right blocks.  
This object has a collider which detects if the over-largened player's collider hits it.  
In case of a collision a new chunk is generated, depending on which side was hit.  
If the left invisible object's collider is colliding with the player's collider, a new chunk is generated to the left.  
The first chunk is always the chunk with index 0, and always initialized.  
The other chunks are only initialized upon the collision method described above.  

## Upon chunk generation
Upon chunk generation, each block within the chunk gets instantiated and put to their correct position.  
Depending on how deep the block, the variety of block increases.  
More details are provided in `GameInfoHolder.md`.
