CREATE OR REPLACE FUNCTION insertar_pago_automatico()
RETURNS TRIGGER AS $$
DECLARE
    precio_cancha numeric(10,2);
BEGIN
    IF NEW.estado = 'PAGADO' AND OLD.estado IS DISTINCT FROM 'PAGADO' THEN
        SELECT precio INTO precio_cancha
        FROM "CanchasDB".cancha
        WHERE id_cancha = NEW.id_cancha;

        INSERT INTO "CanchasDB".pago (reserva_id, fecha, monto)
        VALUES (NEW.reserva_id, CURRENT_DATE, precio_cancha);
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TRIGGER trg_insertar_pago
AFTER UPDATE ON "CanchasDB".reserva
FOR EACH ROW
EXECUTE FUNCTION insertar_pago_automatico();

DROP FUNCTION insertar_pago_automatico;
DROP TRIGGER IF EXISTS trg_insertar_pago ON "CanchasDB".reserva;
SELECT * FROM "CanchasDB".cancha;
