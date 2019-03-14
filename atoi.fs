: ctoi ( c -- u )
  0x30 - dup dup -1 < swap 9 > or if
    throw
    then ;

: pow ( u1 u2 -- u )
  1+ 0 do i .
       i 0= if 1 else over * then
    loop
  .s throw
;

: atoi ( c-addr u -- u )
  2dup 0 max 0 ?do dup c@ ctoi swap 1+ loop
  \ 0 swap 0 do dup v + loop
;
