ALTER TABLE reserva 
ALTER COLUMN horainicio TYPE TIME USING horainicio::TIME;

ALTER TABLE reserva 
ALTER COLUMN horafin TYPE TIME USING horafin::TIME;