: ctoi ( c -- u )
  $30 - dup dup -1 < swap 9 > or if
    throw
    then ;

: pow ( u1 u2 -- u )
  1+ 0 do
       i 0= if 1 else over * then
    loop nip
;

: sum ( u1 u2 .. n -- u )
  0 max 0 ?do i 0= invert  if + then loop
;

: atoi ( c-addr u -- u )
  tuck 1- 0 swap do dup c@ ctoi 10 i pow * swap rot swap 1+ -1 +loop drop
  sum
;

create v2 '1' c, '2' c, '3' c, '4' c,
v2 4 atoi
.s
