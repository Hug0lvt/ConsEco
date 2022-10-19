while [ 0 -eq 0 ]; do
    insert(){
        dev1="'$1'"
        dev2="'$2'"
        date=`date +"%d/%m/%Y:%H:%M:%S"`
        date2="'$date'"
        rep=`curl -s https://www.freeforexapi.com/api/live?pairs=$1$2 | grep rate | cut -d : -f 4 | cut -d , -f 1`
        echo 'DELETE from conversion WHERE device1='$dev1' AND device2='$dev2';INSERT INTO conversion VALUES ('$dev1', '$rep', '$dev2','$date2');' | PGPASSWORD=lulu psql -d piege -U lulu &> /dev/null
        rep=`curl -s https://www.freeforexapi.com/api/live?pairs=$2$1 | grep rate | cut -d : -f 4 | cut -d , -f 1`
        echo 'DELETE from conversion WHERE device1='$dev2' AND device2='$dev1';INSERT INTO conversion VALUES ('$dev2', '$rep', '$dev1','$date2');' | PGPASSWORD=amodif psql -d amodif -U amodif &> /dev/null
    }

    insert EUR USD
    insert EUR GBP
    insert GBP USD
    insert USD JPY
    insert AUD USD
    insert USD CHF
    insert NZD USD
    insert EUR CAD
    insert ZAR USD
    sleep 10
done

