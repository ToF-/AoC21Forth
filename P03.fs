CREATE SAMPLE
2 BASE !
00100 ,
11110 ,
10110 ,
10111 ,
10101 ,
01111 ,
00111 ,
11100 ,
10000 ,
11001 ,
00010 ,
01010 ,
DECIMAL
HERE SAMPLE - CELL / CONSTANT SAMPLE-SIZE

: MOST-COMMON-BIT ( bitp,addr,size -- bit|0 )
    DUP >R 0 -ROT             \ bitp,0,addr,size
    CELLS OVER + SWAP DO      \ bitp,acc
        OVER I @ AND          \ bitp,acc,bit|0
        IF 1+ THEN
    CELL +LOOP                \ bitp,acc
    R> 2/ < IF DROP 0 THEN ;

: LEAST-COMMON-BIT ( bitp,addr,size -- bit|0 )
    DUP >R 0 -ROT             \ bitp,0,addr,size
    CELLS OVER + SWAP DO      \ bitp,acc
        OVER I @ AND          \ bitp,acc,bit|0
        0= IF 1+ THEN
    CELL +LOOP                \ bitp,acc
    R> 2/ < IF DROP 0 THEN ;

2 BASE
1000000000000 CONSTANT MAXBIT
DECIMAL

: BIT-MASK ( n -- bits )
    1 SWAP 0 DO 2* LOOP 1- ;

: MOST-COMMON-BITS ( max,addr,size -- bits ) 
    ROT BIT-MASK -ROT               \ mask,addr,size
    MAXBIT 1 0 -ROT DO              \ mask,addr,size,0
        I 2OVER                     \ mask,addr,size,0,I,addr,size
        MOST-COMMON-BIT             \ mask,addr,size,0,bitp
        OR I +LOOP                  \ mask,addr,size,bitp
    -ROT 2DROP AND ;
    
: LEAST-COMMON-BITS 
    ROT BIT-MASK -ROT
    MAXBIT 1 0 -ROT DO              \ addr,size,0
        I 2OVER                     \ addr,size,0,I,addr,size
        LEAST-COMMON-BIT             \ addr,size,0,bitp
        OR I +LOOP                  \ addr,size,bitp
    -ROT 2DROP AND ;
5 SAMPLE SAMPLE-SIZE MOST-COMMON-BITS 
5 SAMPLE SAMPLE-SIZE LEAST-COMMON-BITS 

." SOLUTION FOR SAMPLE:"  * . CR

INCLUDE Puzzle03Data.fs

12 PUZZLE PUZZLE-SIZE MOST-COMMON-BITS
12 PUZZLE PUZZLE-SIZE LEAST-COMMON-BITS
." SOLUTION FOR PUZZLE:" * . CR
BYE
