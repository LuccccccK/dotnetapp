CREATE TABLE project_mst (
 project_mst_id SERIAL NOT NULL,
 company_id VARCHAR(8) NOT NULL,
 project_name VARCHAR(30) NOT NULL,
 create_staff_id INT NOT NULL,
 create_program VARCHAR(100) NOT NULL,
 create_timestamp TIMESTAMP NOT NULL,
 update_staff_id INT NOT NULL,
 update_program VARCHAR(100) NOT NULL,
 update_timestamp TIMESTAMP NOT NULL
);

ALTER TABLE project_mst ADD CONSTRAINT PK_project_mst PRIMARY KEY (project_mst_id);