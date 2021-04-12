/PROG  T_PREMIER_TRAJ
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "Trajectoire facile";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 27;
MEMORY_SIZE = 1662;
PROTECT     = READ_WRITE;
TCD:  STACK_SIZE        = 0,
      TASK_PRIORITY     = 50,
      TIME_SLICE        = 0,
      BUSY_LAMP_OFF     = 0,
      ABORT_REQUEST     = 0,
      PAUSE_REQUEST     = 0;
DEFAULT_GROUP   = 1,*,*,*,*;
CONTROL_CODE    = 00000000 00000000;
/APPL
/MN
   1:  !par Louis Gobert ;
   2:  !Set de UTOOL et UFRAME ;
   3:  UFRAME_NUM=4 ;
   4:  UTOOL_NUM=1 ;
   5:  CALL T_OUV_PINCE    ;
   6:J P[1] 100% CNT50    ;
   7:J P[2] 12% CNT100    ;
   8:L P[3] 123mm/sec FINE    ;
   9:  MESSAGE[ss]  ;
  10:  CALL T_FERM_PINCE    ;
  11:L P[1] 12mm/sec FINE    ;
  12:J P[2] 12% FINE    ;
  13:  MESSAGE[Fin du programme.]  ;
  14:  IF (RO[11]=ON) THEN ;
  15:  JMP LBL[1] ;
  16:  ELSE  ;
  17:  JMP LBL[2] ;
  18:  ENDIF ;
  19:  IF (RO[1]=OFF) THEN ;
  20:  MESSAGE[Fermer]  ;
  21:  ENDIF ;
  22:  IF (RO[12]=ON) THEN ;
  23:  MESSAGE[12 fermer]  ;
  24:  ENDIF ;
  25:  LBL[2:autreLabel] ;
  26:  LBL[1:lablTest] ;
  27:  MESSAGE[Arrive au label]  ;
/POS
P[1]{
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
P[3]{
   GP1:
    UF : 0, UT: 1, 
    J1=     0.000 deg,  J2=     0.000 deg,  J3=     0.000 deg,
    J4=     0.000 deg,  J5=     0.000 deg,  J6=     0.000 deg
};
/END
