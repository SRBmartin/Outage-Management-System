CREATE TABLE fault_actions_test(
  faid integer GENERATED BY DEFAULT ON NULL AS IDENTITY,
  date_of_action varchar2(32) NOT NULL,
  adesc varchar(256) NOT NULL,
  fid varchar2(32) NOT NULL
);
ALTER TABLE fault_actions_test
ADD(
    CONSTRAINT fa_fk_test FOREIGN KEY (fid) REFERENCES reported_faults_test(fid),
    CONSTRAINT fa_pk_test PRIMARY KEY (faid, fid)
);