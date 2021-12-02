DEFER FORWARD-CMD
DEFER DOWN-CMD
DEFER UP-CMD
DEFER INITIAL

: FORWARD-CMD-1 ( horz,depth,n -- horz+n,depth )
    ROT + SWAP ;

: DOWN-CMD-1 ( horz,depth,n -- horz,depth+n )
    + ;

: UP-CMD-1 ( horz,depth,n -- horz,depth-n )
    NEGATE DOWN-CMD ;

: INITIAL-1 ( -- horz,depth )
    0 0 ;

' FORWARD-CMD-1 IS FORWARD-CMD
' DOWN-CMD-1 IS DOWN-CMD
' UP-CMD-1 IS UP-CMD
' INITIAL-1 IS INITIAL

INITIAL 5 FORWARD-CMD 5 DOWN-CMD 8 FORWARD-CMD 3 UP-CMD 8 DOWN-CMD 2 FORWARD-CMD

." Day 02 A" CR
." SAMPLE POS * DEPTH:"
* . CR
INITIAL
REQUIRE Puzzle02Data.fs
." PUZZLE POS * DEPTH:"
* . CR
CR
: FORWARD-CMD-2 ( horz,aim,depth,x -- horz+x,aim,depth+aim*x )
    >R OVER              \ horz,aim,depth,aim
    R@ * +               \ horz,aim,depth+aim*x
    ROT R> + -ROT ;      \ horz+x,aim,depth+aim*x

: DOWN-CMD-2 ( horz,aim,depth,n -- horz,aim+n,depth )
    ROT + SWAP ;

: UP-CMD-2 ( horz,aim,depth,n -- horz,aim-n,depth )
    NEGATE DOWN-CMD ;

: INITIAL-2 ( -- horz,aim,depth )
    0 0 0 ;

' FORWARD-CMD-2 IS FORWARD-CMD
' DOWN-CMD-2 IS DOWN-CMD
' UP-CMD-2 IS UP-CMD
' INITIAL-2 IS INITIAL

INITIAL 5 FORWARD-CMD 5 DOWN-CMD 8 FORWARD-CMD 3 UP-CMD 8 DOWN-CMD 2 FORWARD-CMD 

." Day 02 B" CR
." SAMPLE POS * DEPTH:"
NIP * .
INITIAL
INCLUDE Puzzle02Data.fs
." PUZZLE POS * DEPTH:"
NIP * . CR
BYE

