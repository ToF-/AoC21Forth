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

: @-- ( addr -- [addr],addr-1 )
    DUP CELL -      \ addr,addr-1
    SWAP @ SWAP ;   \ [addr],addr-1

: WINDOW ( addr -- [addr-2]+[addr-1]+[addr] )
    @-- @-- @--   \ [addr],[addr-1],[addr-2],addr-3
    DROP + + ;

: WINDOW-INCREASES ( addr,size -- n )
    3 - SWAP             \ size-3,addr
    3 CELLS + SWAP       \ addr+3,size-3
    CELLS OVER + SWAP    \ limit,start
    0 -ROT               \ acc,limit,start
    DO
        I CELL - WINDOW
        I WINDOW < IF 1+ THEN
    CELL +LOOP ;

SAMPLE SAMPLE-SIZE WINDOW-INCREASES .
PUZZLE PUZZLE-SIZE WINDOW-INCREASES .
BYE
