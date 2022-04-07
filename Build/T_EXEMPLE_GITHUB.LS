/PROG  T_EXEMPLE_GITHUB
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 28;
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
   2:  RUN test ;
   3:   ;
   4:  RO[1]=OFF ;
   5:  !bonjout ;
   6:  IF (RO[12]=OFF) THEN ;
   7:  MESSAGE[pas bonjour]  ;
   8:  ELSE  ;
   9:  MESSAGE[oui]  ;
  10:  ENDIF ;
  11:  IF (R[12]>123) THEN ;
  12:  MESSAGE[yes]  ;
  13:  ENDIF ;
  14:   ;
  15:   ;
  16:   ;
  17:   ;
  18:  R[69:Valeur maximu]=R[1:valeur min]    ;
  19:   ;
  20:   ;
  21:  FOR R[53]=0 DOWN TO R[69:Valeur maximu] ;
  22:  MESSAGE[test]  ;
  23:  ENDFOR ;
  24:  JMP LBL[1] ;
  25:  LBL[1:test] ;
  26:L P[2] 100mm/sec CNT100 Offset,PR[8]    ;
  27:L P[1:Point de test] 50mm/sec FINE    ;
  28:C P[2]    
     :  P[1:Point de test] 23mm/sec FINE    ;
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
