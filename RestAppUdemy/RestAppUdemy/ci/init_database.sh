for i in `find /home/database/ -name "*.sql" | sort --version-sort`; do mysql -undocker -pdocker rest_with_asp_net_udemy < $i; done;