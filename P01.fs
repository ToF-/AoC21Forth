CREATE SAMPLE
199 ,
200 ,
208 ,
210 ,
200 ,
207 ,
240 ,
269 ,
260 ,
263 ,
HERE SAMPLE - CELL / CONSTANT SAMPLE-SIZE

REQUIRE Puzzle01Data.fs

: INCREASES ( addr,size -- n )
    CELLS OVER +        \ limit
    SWAP CELL +         \ start at cell 1 not 0
    0 -ROT              \ acc, limit, start
    DO                  \ acc
        I CELL - @ I @  \ acc,elem(i-1),elem(i)
        < IF 1+ THEN    \ acc'
    CELL +LOOP ;        \ next address

SAMPLE SAMPLE-SIZE INCREASES .
PUZZLE PUZZLE-SIZE INCREASES .


BYE
