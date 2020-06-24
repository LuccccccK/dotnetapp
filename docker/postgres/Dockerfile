FROM postgres:11

# ロケール（ja_JP）が存在しないため、追加
# postgresql.conf の読み込みで失敗する
RUN localedef -i ja_JP -c -f UTF-8 -A /usr/share/locale/locale.alias ja_JP.UTF-8