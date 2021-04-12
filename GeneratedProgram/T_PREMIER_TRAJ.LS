/PROG  T_PREMIER_TRAJ
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "Trajectoire facile";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 29;
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
   1:  RUN T_REPLI ;
   2:  !par Louis Gobert ;
   3:  !Set de UTOOL et UFRAME ;
   4:  UFRAME_NUM=4 ;
   5:  UTOOL_NUM=1 ;
   6:  CALL T_OUV_PINCE    ;
   7:J P[1] 100% CNT50    ;
   8:  PR[12:Point calcule]=PR[11]    ;
   9:J P[2] 12% CNT100    ;
  10:L P[3] 123mm/sec FINE    ;
  11:  MESSAGE[test]  ;
  12:  CALL T_FERM_PINCE    ;
  13:L P[1] 12mm/sec FINE    ;
  14:J P[2] 12% FINE    ;
  15:  MESSAGE[Fin du programme.]  ;
  16:  IF (RO[11]=ON) THEN ;
  17:  JMP LBL[1] ;
  18:  ELSE  ;
  19:  JMP LBL[2] ;
  20:  ENDIF ;
  21:  IF (RO[1]=OFF) THEN ;
  22:  MESSAGE[Fermer]  ;
  23:  ENDIF ;
  24:  IF (RO[12]=ON) THEN ;
  25:  MESSAGE[12 fermer]  ;
  26:  ENDIF ;
  27:  LBL[2:autreLabel] ;
  28:  LBL[1:lablTest] ;
  29:  MESSAGE[Arrive au label]  ;
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
