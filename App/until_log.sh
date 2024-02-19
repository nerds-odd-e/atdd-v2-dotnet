until docker compose logs $1 | grep -q "$2";
do
	echo "Waiting for \"$2\"..."
	docker compose logs
	sleep 3
done

echo $(date) $1 ready
