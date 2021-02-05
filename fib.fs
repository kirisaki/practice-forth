: fib ( u -- u )
  dup 3 < if drop 1 else 1 1 rot 2 do
    dup rot rot + 
  loop swap drop
  then
;

10 fib
.s
