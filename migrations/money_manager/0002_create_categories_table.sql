--liquibase formatted sql

--changeset uamangeldiev:10
create table money_manager."category#type"
(
    id   varchar(3),
    name varchar(255),

    constraint "pk_category#type" primary key (id)
);
--rollback drop table money_manager."category#type";

--changeset uamangeldiev:20
insert into money_manager."category#type"(id, name)
values ('INC', 'Доходы'),
       ('OUT', 'Расходы');
--rollback ;

--changeset uamangeldiev:30
create table money_manager.categories
(
    id   bigserial,
    type varchar(3)   not null,
    name varchar(255) not null,

    constraint "fk_categories#type" foreign key (type) references "category#type" (id)
);
--rollback drop table money_manager.categories;