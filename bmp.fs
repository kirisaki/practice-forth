: bmp-info { f n | buf fp aw ah ac } ( c-addr u -- n1 n2 u )
  18 chars allocate throw to buf
  f n r/o bin open-file throw to fp

  buf 18 fp read-file throw drop
  1 cells allocate throw to aw
  aw 4 fp read-file throw drop

  aw 3 + c@ if
    aw 4 + $ff c!
    aw 5 + $ff c!
    aw 6 + $ff c!
    aw 7 + $ff c!
  then

  1 cells allocate throw to ah
  ah 4 fp read-file throw drop
  ah 3 + c@ if
    ah 4 + $ff swap c!
    ah 5 + $ff swap c!
    ah 6 + $ff swap c!
    ah 7 + $ff swap c!
  then

  buf 2 fp read-file throw drop
  1 cells allocate throw to ac
  ac 2 fp read-file throw drop

  aw @
  ah @
  ac @
  fp close-file throw
  aw free throw
  ah free throw
  ac free throw
  buf free throw
;

s" sunflower.bmp" bmp-info .s
