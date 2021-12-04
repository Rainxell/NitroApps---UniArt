export function dateDiff (date:Date) {
  const today = new Date();
  const totalDays = (d:Date) => {return d.getFullYear()*10000 + (d.getMonth()+1)*100 + d.getDate()}
  const ddiff = totalDays(today) - totalDays(date)
  if ( ddiff < 30) { return ddiff + " días"; }
  if ( ddiff < 365 ) { return Math.round(ddiff/30) + " meses"; }
  return Math.round(ddiff/365) + " años";
};

const months = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio',
                'Agosto', 'Setiembre', 'Octubre', 'Noviembre', 'Diciembre']
export function dateToStr(date:Date) {
  const aux = new Date(date);
  return `el ${aux.getDate()} de ${months[aux.getMonth()]} del ${aux.getFullYear()}`
};
