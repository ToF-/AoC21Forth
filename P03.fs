2 BASE !
        11111 CONSTANT  5BITS-MASK
 111111111111 CONSTANT 12BITS-MASK
1000000000000 CONSTANT MAXBIT
CREATE SAMPLE
00100 , 11110 , 10110 , 10111 , 10101 , 01111 , 00111 , 11100 , 10000 , 11001 , 00010 , 01010 ,
HERE SAMPLE - CELL / CONSTANT SAMPLE-SIZE
DECIMAL

DEFER PREDICATE
: IS-SET ;
: IS-CLEAR 0= ;

: MOST-COMMON-BIT ( bitp,addr,size -- bit|0 )
    DUP >R 0 -ROT             \ bitp,0,addr,size
    CELLS OVER + SWAP DO      \ bitp,acc
        OVER I @ AND          \ bitp,acc,bit|0
        PREDICATE IF 1+ THEN
    CELL +LOOP                \ bitp,acc
    R> 2/ < IF DROP 0 THEN ;

: MOST-COMMON-BITS ( addr,size -- bits )
    MAXBIT 1                  \ addr,size,limit,1
    0 -ROT                    \ addr,size,acc,limit,1
    DO                        \ addr,size,acc
        I                     \ addr,size,acc,I = bitp
        2OVER MOST-COMMON-BIT \ addr,size,acc,bitp
        OR                    \ addr,size,
    I +LOOP                   \ addr,size,bitp *= 2
    -ROT 2DROP ;

' IS-SET IS PREDICATE
SAMPLE SAMPLE-SIZE MOST-COMMON-BITS 5BITS-MASK AND
' IS-CLEAR IS PREDICATE
SAMPLE SAMPLE-SIZE MOST-COMMON-BITS 5BITS-MASK AND
." SOLUTION FOR SAMPLE:"  * . CR
INCLUDE Puzzle03Data.fs
' IS-SET IS PREDICATE
PUZZLE PUZZLE-SIZE MOST-COMMON-BITS 12BITS-MASK AND
' IS-CLEAR IS PREDICATE
PUZZLE PUZZLE-SIZE MOST-COMMON-BITS 12BITS-MASK AND
." SOLUTION FOR PUZZLE:" * . CR
BYE
