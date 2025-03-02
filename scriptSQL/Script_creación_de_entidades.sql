-- CUANDO SE EJECUTE EXITOSAMENTE EL COMANDO PARA CREA LA BASE DE DATOS
-- SE DEBE ESPECIFICAR QUE SE TRABAJARA SOBRE ESTA BASE DE DATOS ANTES
-- DE SEGUIR EJECUTANDO EL RESTO DE COMANDOS PARA QUE SU IMPLEMENTACIÓN
-- SEA CORRECTA.

CREATE DATABASE PruebaTecnica;

-- CREACIÓN DE TABLAS
CREATE TABLE IF NOT EXISTS CLIENTE (
    CEDULA VARCHAR(15) PRIMARY KEY,
    NOMBRE VARCHAR(100) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL
);

CREATE TABLE IF NOT EXISTS PRODUCTOS (
    ID VARCHAR(10) PRIMARY KEY,
    NOMBRE VARCHAR(100) NOT NULL,
    VALOR DECIMAL(10,2) NOT NULL CHECK (VALOR > 0)
);

CREATE TABLE IF NOT EXISTS FACTURA (
    NO_FACTURA INT NOT NULL,
    CLIENTE VARCHAR(15) NOT NULL,
    PRODUCTO VARCHAR(10) NOT NULL,
    FOREIGN KEY (CLIENTE) REFERENCES CLIENTE(CEDULA),
    FOREIGN KEY (PRODUCTO) REFERENCES PRODUCTOS(ID)
);

-- INSERTAR DATOS
INSERT INTO CLIENTE (CEDULA, NOMBRE, TELEFONO) VALUES
('234567896', 'JUAN CASAS', '3102334567'),
('123983874', 'MARIA MESA', '3102334561'),
('298767639', 'JULIO COCINA', '3102334562'),
('098273646', 'ANDRES DIAS', '3102334563')
ON CONFLICT (CEDULA) DO NOTHING;

INSERT INTO PRODUCTOS (ID, NOMBRE, VALOR) VALUES
('P000000001', 'MEDIAS LARGAS', 15200),
('P000000002', 'MEDIAS CORTAS', 12400),
('P000000003', 'MEDIAS AZULES', 14100),
('P000000004', 'MEDIAS ROTAS', 10000)
ON CONFLICT (ID) DO NOTHING;

INSERT INTO FACTURA (NO_FACTURA, CLIENTE, PRODUCTO) VALUES
(1, '234567896', 'P000000002'),
(1, '234567896', 'P000000003'),
(2, '298767639', 'P000000001'),
(3, '098273646', 'P000000002'),
(3, '098273646', 'P000000004'),
(4, '234567896', 'P000000001'),
(4, '234567896', 'P000000002'),
(4, '234567896', 'P000000001');
