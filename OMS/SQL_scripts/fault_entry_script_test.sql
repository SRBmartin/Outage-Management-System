CREATE TABLE reported_faults_test(
    fid varchar2(32) NOT NULL,
    date_of_fault varchar2(10) DEFAULT TO_CHAR(SYSDATE, 'yyyy-MM-dd') NOT NULL,
    fstatus varchar(32) DEFAULT 'Unconfirmed',
    fshort_desc varchar2(256) NOT NULL,
    ecid integer NOT NULL,
    fdesc varchar(1024) NOT NULL
);
ALTER TABLE reported_faults_test
ADD (
    constraint rp_pk_test PRIMARY KEY (fid),
    constraint rp_ck_test CHECK (fstatus IN ('Unconfirmed', 'In service', 'Testing', 'Closed')),
    constraint rp_fk_test FOREIGN KEY (ecid) REFERENCES electronic_components_test(ecid)
);
CREATE SEQUENCE reported_faults_seq_test
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE
    CACHE 20;
CREATE OR REPLACE TRIGGER reported_faults_trigger_test
BEFORE INSERT ON reported_faults_test
FOR EACH ROW
DECLARE
    last_date_test DATE;
    new_sequence_test NUMBER;
BEGIN
    SELECT MAX(TO_DATE(SUBSTR(fid, 1, 14), 'YYYYMMDDHH24MISS'))
    INTO last_date_test
    FROM reported_faults_test;

    IF last_date_test IS NULL OR TRUNC(last_date_test) <> TRUNC(SYSDATE) THEN
        -- Reset sequence for a new date
        SELECT reported_faults_seq_test.NEXTVAL INTO new_sequence_test FROM DUAL;
    ELSE
        -- Increment sequence for the same date
        SELECT reported_faults_seq_test.NEXTVAL INTO new_sequence_test FROM DUAL;
    END IF;

    :NEW.fid := TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS') || '_' || TO_CHAR(new_sequence_test, 'FM000000');
END;
/
