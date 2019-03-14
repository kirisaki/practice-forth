: ctoi ( c -- n )
  0x30 - dup 10 > if
    throw
    then ;
