# MongodbAutoBackup
mongodb auto backup application


This application is responsible for getting backup from mongodb databases automatically.

It uses Quartz.net library for auto backup schedule.
Quartz.net docs => https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/

All the settings are saved inside appSettings. After changing the configs we have to click Apply button to restart the backup scheduler.
