--liquibase formatted sql

--changeset uamangeldiev:10
create schema money_manager;
--rollback drop schema money_manager;