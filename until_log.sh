until docker compose logs $1 | grep -q "$2";
do
	echo "Waiting for \"$2\"..."
	sleep 1
done

echo $(date) $1 ready
