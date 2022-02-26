function [potential] = FindPotential(Zwroty_z_pilka,Bieg_bez_pilki ,zonglerka,prowadzenie_pilki,skok_w_dal)

a=readfis('FindPotential');
potential=evalfis(a,[Zwroty_z_pilka;Bieg_bez_pilki;zonglerka;prowadzenie_pilki;skok_w_dal]);


end
