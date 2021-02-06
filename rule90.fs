: see_bit { byte num } ( c u -- flag )
   $80 num rshift byte and if $ff else $00 then
;

: neighbor { addr index len | byte bit s1 s2 s3 } ( c-addr u u -- c )
  index len > if throw then
  index 8 / to byte
  index 8 mod to bit
  index 0= if 0 else bit 0= if addr byte 1- + c@ 7 see_bit else addr byte + c@ bit 1- see_bit then then to s1
  addr byte + c@ bit see_bit to s2
  index len 1- = if 0 else bit 7 = if addr byte 1+ + c@ 0 see_bit else addr byte + c@ bit 1+ see_bit then then to s3
  %10000000 s1 and %01000000 s2 and %00100000 s3 and or or
;

: select { st } ( c --- flag )
  st %11100000 and case
  %00000000 of false endof
  %00100000 of true endof
  %01000000 of false endof
  %01100000 of true endof
  %10000000 of true endof
  %10100000 of false endof
  %11000000 of true endof
  %11100000 of false endof
  false
  endcase
;

: step { before len | blocks index after } ( c-addr u -- c-addr )
  len 8 / 1+ to blocks
  blocks allocate drop to after
  blocks 0 do
    8 0 do
      8 j * i + to index
      before index len neighbor
      select if after j + c@ %10000000 i rshift or after j + c! then
      index 1+ len >= if leave then
    loop
  loop
  before free drop
  after
;

: from_str { src len | blocks dest index } ( c-addr u -- c-addr )
  len 8 / 1+ to blocks
  blocks allocate drop to dest
  blocks 0 do
    8 0 do
      8 j * i + to index
      src index + c@ '1' = if $80 i rshift dest j + c@ or dest j + c! then
      index 1+ len >= if leave then
    loop
  loop
  dest
;

: display { st len | blocks buf index } ( c-addr u -- )
  len 8 / 1+ to blocks
  len allocate drop to buf
  len 0 do
    $20 buf i + c!
  loop
  blocks 0 do
    8 0 do
      8 j * i + to index
      st j + c@ i see_bit if $2A buf index + c! then
      index 1+ len >= if leave then
    loop
  loop
  buf len type cr
  buf free drop
;

: rule90 { str len itr } ( c-addr u u -- )
  cr
  str len from_str
  itr 0 do
    dup len display
    len step
  loop
  len display
;

\ S" 000000000000000000000001010000000000000000000000
\ 30
\ rule90
