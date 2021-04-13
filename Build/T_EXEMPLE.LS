/PROG  T_EXEMPLE
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 21;
MEMORY_SIZE = 1662;
PROTECT     = READ_WRITE;
TCD:  STACK_SIZE        = 0,
      TASK_PRIORITY     = 50,
      TIME_SLICE        = 0,
      BUSY_LAMP_OFF     = 0,
      ABORT_REQUEST     = 0,
      PAUSE_REQUEST     = 0;
DEFAULT_GROUP   = *,*,*,*,*;
CONTROL_CODE    = 00000000 00000000;
/APPL
/MN
   1:   ;
   2:   ;
   3:   ;
   4:   ;
   5:   ;
   6:  R[69:Valeur maximu]=R[1:valeur min]    ;
   7:   ;
   8:  FOR R[53]=0 TO R[69:Valeur maximu] ;
   9:  MESSAGE[test]  ;
  10:  ENDFOR ;
  11:   ;
  12:   ;
  13:   ;
  14:L PR[12] 100mm/sec CNT100    ;
  15:   ;
  16:J P[1:Point de test] 100% CNT100    ;
  17:L P[1:Point de test] 50mm/sec FINE    ;
  18:   ;
  19:   ;
  20:C P[2]    
     :  P[1:Point de test] 23mm/sec FINE    ;
  21:   ;
/POS
P[1:"Point de test"]{
   GP1:
    UF : 0, UT: 1, 
    J1=     0.000 deg,  J2=     0.000 deg,  J3=     0.000 deg,
    J4=     0.000 deg,  J5=     0.000 deg,  J6=     0.000 deg
};
P[2]{
   GP1:
    UF : 0, UT: 1, 
    J1=     0.000 deg,  J2=     0.000 deg,  J3=     0.000 deg,
    J4=     0.000 deg,  J5=     0.000 deg,  J6=     0.000 deg
};
/END
