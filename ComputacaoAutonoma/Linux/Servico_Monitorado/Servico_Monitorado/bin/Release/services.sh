#!/bin/bash

PROGRAM_NAME="Servico_Monitorado"
LOCK_FILE="/tmp/"${PROGRAM_NAME}".lock"

usage()
{
    echo "$0 (start|stop)"
}

stop()
{
    if [ -e ${LOCK_FILE} ]
    then
        _pid=$(cat ${LOCK_FILE})
        kill $_pid
        rt=$?
        if [ "$rt" == "0" ]
	    then
	    	echo "Serviço monitorado parado"
	    else
	    	echo "Erro parando serviço monitorado"
        fi
    else
    	echo "Serviço monitorado já se encontra parado"
    fi
}

start()
{
 	if [ -e ${LOCK_FILE} ]
    then
        echo "Serviço monitorado já se encontra iniciado"
    else 
    	mono-service -l:${LOCK_FILE} ./${PROGRAM_NAME}.exe
    	echo "Serviço monitorado iniciado"
    fi
   
}

case $1 in
    "start")
            start
            ;;
    "stop")
            stop
            ;;
    *)
            usage
            ;;
esac
exit


