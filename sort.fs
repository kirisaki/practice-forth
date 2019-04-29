: aswap ( u1 u2 a-addr --  )
  dup rot cells + rot cells + 2dup @ swap @  rot ! swap !
;

variable v1
create v1 2 cells allot
10 v1 !
20 v1 cell+ !
v1 @ .
v1 cell+ @ .
0 1 v1 aswap
v1 @ .
v1 cell+ @ .
