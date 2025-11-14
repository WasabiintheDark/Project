-- DROP OLD TABLES (if exist)
DROP TABLE IF EXISTS time_entries CASCADE;
DROP TABLE IF EXISTS assignments CASCADE;
DROP TABLE IF EXISTS project_tasks CASCADE;
DROP TABLE IF EXISTS projects CASCADE;
DROP TABLE IF EXISTS employee_skills CASCADE;
DROP TABLE IF EXISTS skills CASCADE;
DROP TABLE IF EXISTS work_calendars CASCADE;
DROP TABLE IF EXISTS workload_rules CASCADE;
DROP TABLE IF EXISTS holidays CASCADE;
DROP TABLE IF EXISTS employees CASCADE;
DROP TABLE IF EXISTS positions CASCADE;
DROP TABLE IF EXISTS departments CASCADE;

-- CREATE TABLES

CREATE TABLE departments (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE positions (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE employees (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    phone VARCHAR(50),
    hire_date DATE NOT NULL,
    department_id INT NOT NULL REFERENCES departments(id),
    position_id INT NOT NULL REFERENCES positions(id)
);

CREATE TABLE skills (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE employee_skills (
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE CASCADE,
    skill_id INT NOT NULL REFERENCES skills(id) ON DELETE CASCADE,
    level INT NOT NULL,
    PRIMARY KEY (employee_id, skill_id)
);

CREATE TABLE projects (
    id SERIAL PRIMARY KEY,
    name VARCHAR(200) NOT NULL UNIQUE,
    start_date DATE NOT NULL,
    end_date DATE,
    status INT NOT NULL
);

CREATE TABLE project_tasks (
    id SERIAL PRIMARY KEY,
    project_id INT NOT NULL REFERENCES projects(id) ON DELETE CASCADE,
    title VARCHAR(200) NOT NULL,
    description TEXT,
    planned_hours INT NOT NULL,
    due_date DATE NOT NULL
);

CREATE TABLE assignments (
    id SERIAL PRIMARY KEY,
    task_id INT NOT NULL REFERENCES project_tasks(id) ON DELETE CASCADE,
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE CASCADE,
    allocation_percent INT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL
);

CREATE TABLE work_calendars (
    id SERIAL PRIMARY KEY,
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE CASCADE,
    work_day DATE NOT NULL,
    capacity_hours INT NOT NULL,
    is_holiday BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE holidays (
    id SERIAL PRIMARY KEY,
    day DATE NOT NULL UNIQUE,
    name VARCHAR(200) NOT NULL
);

CREATE TABLE workload_rules (
    id SERIAL PRIMARY KEY,
    name VARCHAR(200) NOT NULL UNIQUE,
    max_allocation_percent INT NOT NULL,
    notes TEXT
);

CREATE TABLE time_entries (
    id SERIAL PRIMARY KEY,
    employee_id INT NOT NULL REFERENCES employees(id) ON DELETE CASCADE,
    task_id INT NOT NULL REFERENCES project_tasks(id) ON DELETE CASCADE,
    spent_hours INT NOT NULL,
    entry_date DATE NOT NULL
);

-- INSERT DATA

INSERT INTO departments (name) VALUES
('IT'),
('HR'),
('Finance'),
('Marketing');

INSERT INTO positions (name) VALUES
('Developer'),
('QA Engineer'),
('Project Manager'),
('Designer');

INSERT INTO employees (first_name, last_name, email, phone, hire_date, department_id, position_id) VALUES
('John', 'Doe', 'john.doe@company.com', '123456789', '2022-02-01', 1, 1),
('Anna', 'Smith', 'anna.smith@company.com', '987654321', '2021-05-10', 1, 2),
('Bob', 'Johnson', 'bob.johnson@company.com', '555555555', '2020-07-18', 4, 4);

INSERT INTO skills (name) VALUES
('C#'),
('SQL'),
('JavaScript'),
('Design'),
('QA Testing');

INSERT INTO employee_skills (employee_id, skill_id, level) VALUES
(1, 1, 4),
(1, 2, 3),
(2, 5, 5),
(3, 4, 4);

INSERT INTO projects (name, start_date, end_date, status) VALUES
('CRM System Upgrade', '2023-01-15', '2023-06-30', 1),
('Website Redesign', '2023-02-10', '2023-08-01', 0);

INSERT INTO project_tasks (project_id, title, description, planned_hours, due_date) VALUES
(1, 'API implementation', 'Implement rest API', 120, '2023-04-20'),
(1, 'Database optimization', 'Tune SQL queries', 60, '2023-05-15'),
(2, 'UI Layout', 'Create new UI layout', 80, '2023-07-01');

INSERT INTO assignments (task_id, employee_id, allocation_percent, start_date, end_date) VALUES
(1, 1, 50, '2023-02-01', '2023-04-20'),
(2, 1, 30, '2023-03-01', '2023-05-15'),
(3, 3, 40, '2023-03-05', '2023-07-01');

INSERT INTO work_calendars (employee_id, work_day, capacity_hours, is_holiday) VALUES
(1, '2023-02-01', 8, FALSE),
(1, '2023-02-02', 8, FALSE),
(2, '2023-02-01', 6, FALSE),
(3, '2023-02-01', 0, TRUE);

INSERT INTO holidays (day, name) VALUES
('2023-01-01', 'New Year'),
('2023-05-09', 'Victory Day');

INSERT INTO workload_rules (name, max_allocation_percent, notes) VALUES
('Default Rule', 80, 'Maximum 80% allocation'),
('Overtime Rule', 120, 'Can work overtime if needed');

INSERT INTO time_entries (employee_id, task_id, spent_hours, entry_date) VALUES
(1, 1, 5, '2023-02-01'),
(1, 1, 6, '2023-02-02'),
(3, 3, 7, '2023-02-01');
