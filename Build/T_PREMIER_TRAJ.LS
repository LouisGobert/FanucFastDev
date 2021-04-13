/PROG  T_PREMIER_TRAJ
/ATTR
OWNER       = MNEDITOR;
COMMENT     = "Trajectoire facile";
PROG_SIZE   = 1382;
CREATE      = DATE 20-10-15  TIME 15:42:30;
MODIFIED    = DATE 20-10-15  TIME 16:10:46;
FILE_NAME   = ;
VERSION     = 0;
LINE_COUNT  = 55;
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
   1:   ;
   2:  RUN T_REPLI ;
   3:   ;
   4:  F[1]=OFF ;
   5:   ;
   6:  IF (F[1]=ON AND F[2]=OFF OR F[2]=ON) THEN ;
   7:  !test ;
   8:  JMP LBL[1] ;
   9:  ENDIF ;
  10:   ;
  11:   ;
  12:   ;
  13:  !par Louis Gobert ;
  14:  !Set de UTOOL et UFRAME ;
  15:  UFRAME_NUM=4 ;
  16:  UTOOL_NUM=1 ;
  17:  CALL T_OUV_PINCE    ;
  18:   ;
  19:J P[1] 100% CNT50    ;
  20:   ;
  21:   ;
  22:  PR[12:Point calcule]=PR[11]    ;
  23:   ;
  24:J P[2] 12% CNT100    ;
  25:L P[3] 123mm/sec FINE    ;
  26:  MESSAGE[Prise de la piece]  ;
  27:  CALL T_FERM_PINCE    ;
  28:   ;
  29:L P[1] 12mm/sec FINE    ;
  30:J P[2] 12% FINE    ;
  31:   ;
  32:  MESSAGE[Fin du programme.]  ;
  33:   ;
  34:   ;
  35:  IF (RO[11]=ON) THEN ;
  36:  JMP LBL[2] ;
  37:  ELSE  ;
  38:  JMP LBL[1] ;
  39:  ENDIF ;
  40:  LBL[1:autreLabel] ;
  41:   ;
  42:  IF (RO[1]=OFF) THEN ;
  43:  MESSAGE[Fermer]  ;
  44:  ENDIF ;
  45:  IF (RO[12]=ON) THEN ;
  46:  MESSAGE[12 fermer]  ;
  47:  ENDIF ;
  48:   ;
  49:   ;
  50:   ;
  51:   ;
  52:  LBL[2:lablTest] ;
  53:  MESSAGE[Arrive au label]  ;
  54:   ;
  55:   ;
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
