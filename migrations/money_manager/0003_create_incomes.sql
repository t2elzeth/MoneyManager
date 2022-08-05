--liquibase formatted sql

--changeset uamangeldiev:
create table money_manager.incomes
(
    id                bigserial,
    category_id       bigint  not null,
    amount            decimal not null,
    created_date_time timestamp without time zone,

    constraint incomes_category_id foreign key (category_id) references money_manager.categories (id)
);
--rollback drop table money_manager.incomes;