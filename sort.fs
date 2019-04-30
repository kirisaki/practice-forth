: aswap ( u1 u2 a-addr --  )
  dup rot cells + rot cells + 2dup @ swap @  rot ! swap !
;

: mswap ( a-addr1 a-addr2 -- )
  2dup @ swap @ rot ! swap !
;

: bubble ( u a-addr -- )
  swap dup 1- 0 max 0 ?do
    dup i - 1+ 1 max 1 ?do
      swap  dup i 1- cells + over i cells + 2dup @ swap @ swap < if mswap else 2drop then  swap
    loop
  loop
  2drop
;

: ashow ( u a-addr -- )
  swap dup 0 max 0 ?do
    swap dup i cells + @ . swap
  loop
  2drop
;

variable v1
create v1 8 cells allot
8 v1 0 cells + !
4 v1 1 cells + !
3 v1 2 cells + !
7 v1 3 cells + !
6 v1 4 cells + !
5 v1 5 cells + !
2 v1 6 cells + !
1 v1 7 cells + !
8 v1 bubble
.s
8 v1 ashow
