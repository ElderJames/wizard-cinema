<template lang="pug">
  Layout(:has_share="false" title="选座")
    .body(style='visibility: visible;')
      section.seat-block
        .info-block
          .movie-info.box-flex.middle
            .flex
              .title.line-ellipsis 影
              .info.line-ellipsis
                span 2018-10-16 19:30
                span(style='margin-left: 5px; ') 国语2D
          ul.reminder-list
            li.reminder-item
              img(src='http://p1.meituan.net/movie/77717de09967c29cd5b3d1f76309ac841254.png')
              div 13岁以下儿童应在家长陪同下观看
              span.reminder-num(style='display: none;')
                | 1个通知
                i.fold-down
        .select-block()
          .seat-block-wrap(style='visibility: visible;')
            .hall-name-wrapper.animate()
              span.hall-name IMAX厅
            .row-nav.animate()
              div 2
              div 3
              div 4
              div 5
              div 6
              div 7
              div 8
              div 9
              div 10
              div 11
            .seats-block.animate(v-drag="true" )
              .m-line(style="-webkit-transform: translateX(-23px);transform: translateX(-23px);")
                .divider(style="-webkit-transform: translateX(-23px);transform: translateX(-23px);")
              .seats-wrap(data-sectionid='1', data-sectionname='花城汇IMAX', style='width: 1426px;')
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"1", "rowId": "2", "columnId": "1", "type": "N", "seatNo": "9,30,0000000001"}', data-status='0', data-id='9,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"2", "rowId": "2", "columnId": "2", "type": "N", "seatNo": "9,29,0000000001"}', data-status='0', data-id='9,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"3", "rowId": "2", "columnId": "3", "type": "N", "seatNo": "9,28,0000000001"}', data-status='0', data-id='9,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"4", "rowId": "2", "columnId": "4", "type": "N", "seatNo": "9,27,0000000001"}', data-status='0', data-id='9,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"5", "rowId": "2", "columnId": "5", "type": "N", "seatNo": "9,26,0000000001"}', data-status='0', data-id='9,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"6", "rowId": "2", "columnId": "6", "type": "N", "seatNo": "9,25,0000000001"}', data-status='0', data-id='9,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"7", "rowId": "2", "columnId": "7", "type": "N", "seatNo": "9,24,0000000001"}', data-status='0', data-id='9,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"8", "rowId": "2", "columnId": "8", "type": "N", "seatNo": "9,23,0000000001"}', data-status='0', data-id='9,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"9", "rowId": "2", "columnId": "9", "type": "N", "seatNo": "9,22,0000000001"}', data-status='0', data-id='9,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"10", "rowId": "2", "columnId": "10", "type": "N", "seatNo": "9,21,0000000001"}', data-status='0', data-id='9,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"11", "rowId": "2", "columnId": "11", "type": "N", "seatNo": "9,20,0000000001"}', data-status='0', data-id='9,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"12", "rowId": "2", "columnId": "12", "type": "N", "seatNo": "9,19,0000000001"}', data-status='0', data-id='9,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"13", "rowId": "2", "columnId": "13", "type": "N", "seatNo": "9,18,0000000001"}', data-status='0', data-id='9,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"14", "rowId": "2", "columnId": "14", "type": "N", "seatNo": "9,17,0000000001"}', data-status='0', data-id='9,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"15", "rowId": "2", "columnId": "15", "type": "N", "seatNo": "9,16,0000000001"}', data-status='0', data-id='9,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"16", "rowId": "2", "columnId": "16", "type": "N", "seatNo": "9,15,0000000001"}', data-status='0', data-id='9,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"17", "rowId": "2", "columnId": "17", "type": "N", "seatNo": "9,14,0000000001"}', data-status='0', data-id='9,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"18", "rowId": "2", "columnId": "18", "type": "N", "seatNo": "9,13,0000000001"}', data-status='0', data-id='9,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"19", "rowId": "2", "columnId": "19", "type": "N", "seatNo": "9,12,0000000001"}', data-status='0', data-id='9,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"20", "rowId": "2", "columnId": "20", "type": "N", "seatNo": "9,11,0000000001"}', data-status='0', data-id='9,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"21", "rowId": "2", "columnId": "21", "type": "N", "seatNo": "9,10,0000000001"}', data-status='0', data-id='9,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"22", "rowId": "2", "columnId": "22", "type": "N", "seatNo": "9,9,0000000001"}', data-status='0', data-id='9,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"23", "rowId": "2", "columnId": "23", "type": "N", "seatNo": "9,8,0000000001"}', data-status='0', data-id='9,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"24", "rowId": "2", "columnId": "24", "type": "N", "seatNo": "9,7,0000000001"}', data-status='0', data-id='9,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"25", "rowId": "2", "columnId": "25", "type": "N", "seatNo": "9,6,0000000001"}', data-status='0', data-id='9,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"26", "rowId": "2", "columnId": "26", "type": "N", "seatNo": "9,5,0000000001"}', data-status='0', data-id='9,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"27", "rowId": "2", "columnId": "27", "type": "N", "seatNo": "9,4,0000000001"}', data-status='0', data-id='9,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"28", "rowId": "2", "columnId": "28", "type": "N", "seatNo": "9,3,0000000001"}', data-status='0', data-id='9,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"30", "rowId": "2", "columnId": "29", "type": "N", "seatNo": "9,1,0000000001"}', data-status='0', data-id='9,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"1", "column":"31", "rowId": "2", "columnId": "30", "type": "N", "seatNo": "9,0,0000000001"}', data-status='0', data-id='9,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 2排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"1", "rowId": "3", "columnId": "1", "type": "N", "seatNo": "8,30,0000000001"}', data-status='0', data-id='8,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"2", "rowId": "3", "columnId": "2", "type": "N", "seatNo": "8,29,0000000001"}', data-status='0', data-id='8,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"3", "rowId": "3", "columnId": "3", "type": "N", "seatNo": "8,28,0000000001"}', data-status='0', data-id='8,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"4", "rowId": "3", "columnId": "4", "type": "N", "seatNo": "8,27,0000000001"}', data-status='0', data-id='8,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"5", "rowId": "3", "columnId": "5", "type": "N", "seatNo": "8,26,0000000001"}', data-status='0', data-id='8,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"6", "rowId": "3", "columnId": "6", "type": "N", "seatNo": "8,25,0000000001"}', data-status='0', data-id='8,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"7", "rowId": "3", "columnId": "7", "type": "N", "seatNo": "8,24,0000000001"}', data-status='0', data-id='8,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"8", "rowId": "3", "columnId": "8", "type": "N", "seatNo": "8,23,0000000001"}', data-status='0', data-id='8,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"9", "rowId": "3", "columnId": "9", "type": "N", "seatNo": "8,22,0000000001"}', data-status='0', data-id='8,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"10", "rowId": "3", "columnId": "10", "type": "N", "seatNo": "8,21,0000000001"}', data-status='0', data-id='8,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"11", "rowId": "3", "columnId": "11", "type": "N", "seatNo": "8,20,0000000001"}', data-status='0', data-id='8,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"12", "rowId": "3", "columnId": "12", "type": "N", "seatNo": "8,19,0000000001"}', data-status='0', data-id='8,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"13", "rowId": "3", "columnId": "13", "type": "N", "seatNo": "8,18,0000000001"}', data-status='0', data-id='8,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"14", "rowId": "3", "columnId": "14", "type": "N", "seatNo": "8,17,0000000001"}', data-status='0', data-id='8,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"15", "rowId": "3", "columnId": "15", "type": "N", "seatNo": "8,16,0000000001"}', data-status='0', data-id='8,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"16", "rowId": "3", "columnId": "16", "type": "N", "seatNo": "8,15,0000000001"}', data-status='0', data-id='8,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"17", "rowId": "3", "columnId": "17", "type": "N", "seatNo": "8,14,0000000001"}', data-status='0', data-id='8,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"18", "rowId": "3", "columnId": "18", "type": "N", "seatNo": "8,13,0000000001"}', data-status='0', data-id='8,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"19", "rowId": "3", "columnId": "19", "type": "N", "seatNo": "8,12,0000000001"}', data-status='0', data-id='8,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"20", "rowId": "3", "columnId": "20", "type": "N", "seatNo": "8,11,0000000001"}', data-status='0', data-id='8,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"21", "rowId": "3", "columnId": "21", "type": "N", "seatNo": "8,10,0000000001"}', data-status='0', data-id='8,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"22", "rowId": "3", "columnId": "22", "type": "N", "seatNo": "8,9,0000000001"}', data-status='0', data-id='8,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"23", "rowId": "3", "columnId": "23", "type": "N", "seatNo": "8,8,0000000001"}', data-status='0', data-id='8,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"24", "rowId": "3", "columnId": "24", "type": "N", "seatNo": "8,7,0000000001"}', data-status='0', data-id='8,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"25", "rowId": "3", "columnId": "25", "type": "N", "seatNo": "8,6,0000000001"}', data-status='0', data-id='8,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"26", "rowId": "3", "columnId": "26", "type": "N", "seatNo": "8,5,0000000001"}', data-status='0', data-id='8,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"27", "rowId": "3", "columnId": "27", "type": "N", "seatNo": "8,4,0000000001"}', data-status='0', data-id='8,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"28", "rowId": "3", "columnId": "28", "type": "N", "seatNo": "8,3,0000000001"}', data-status='0', data-id='8,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"30", "rowId": "3", "columnId": "29", "type": "N", "seatNo": "8,1,0000000001"}', data-status='0', data-id='8,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"2", "column":"31", "rowId": "3", "columnId": "30", "type": "N", "seatNo": "8,0,0000000001"}', data-status='0', data-id='8,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 3排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"1", "rowId": "4", "columnId": "1", "type": "N", "seatNo": "7,30,0000000001"}', data-status='0', data-id='7,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"2", "rowId": "4", "columnId": "2", "type": "N", "seatNo": "7,29,0000000001"}', data-status='0', data-id='7,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"3", "rowId": "4", "columnId": "3", "type": "N", "seatNo": "7,28,0000000001"}', data-status='0', data-id='7,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"4", "rowId": "4", "columnId": "4", "type": "N", "seatNo": "7,27,0000000001"}', data-status='0', data-id='7,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"5", "rowId": "4", "columnId": "5", "type": "N", "seatNo": "7,26,0000000001"}', data-status='0', data-id='7,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"6", "rowId": "4", "columnId": "6", "type": "N", "seatNo": "7,25,0000000001"}', data-status='0', data-id='7,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"7", "rowId": "4", "columnId": "7", "type": "N", "seatNo": "7,24,0000000001"}', data-status='0', data-id='7,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"8", "rowId": "4", "columnId": "8", "type": "N", "seatNo": "7,23,0000000001"}', data-status='0', data-id='7,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"9", "rowId": "4", "columnId": "9", "type": "N", "seatNo": "7,22,0000000001"}', data-status='0', data-id='7,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"10", "rowId": "4", "columnId": "10", "type": "N", "seatNo": "7,21,0000000001"}', data-status='0', data-id='7,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"11", "rowId": "4", "columnId": "11", "type": "N", "seatNo": "7,20,0000000001"}', data-status='0', data-id='7,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"12", "rowId": "4", "columnId": "12", "type": "N", "seatNo": "7,19,0000000001"}', data-status='0', data-id='7,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"13", "rowId": "4", "columnId": "13", "type": "N", "seatNo": "7,18,0000000001"}', data-status='0', data-id='7,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"14", "rowId": "4", "columnId": "14", "type": "N", "seatNo": "7,17,0000000001"}', data-status='0', data-id='7,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"15", "rowId": "4", "columnId": "15", "type": "N", "seatNo": "7,16,0000000001"}', data-status='0', data-id='7,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"16", "rowId": "4", "columnId": "16", "type": "N", "seatNo": "7,15,0000000001"}', data-status='0', data-id='7,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"17", "rowId": "4", "columnId": "17", "type": "N", "seatNo": "7,14,0000000001"}', data-status='0', data-id='7,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"18", "rowId": "4", "columnId": "18", "type": "N", "seatNo": "7,13,0000000001"}', data-status='0', data-id='7,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"19", "rowId": "4", "columnId": "19", "type": "N", "seatNo": "7,12,0000000001"}', data-status='0', data-id='7,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"20", "rowId": "4", "columnId": "20", "type": "N", "seatNo": "7,11,0000000001"}', data-status='0', data-id='7,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"21", "rowId": "4", "columnId": "21", "type": "N", "seatNo": "7,10,0000000001"}', data-status='0', data-id='7,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"22", "rowId": "4", "columnId": "22", "type": "N", "seatNo": "7,9,0000000001"}', data-status='0', data-id='7,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"23", "rowId": "4", "columnId": "23", "type": "N", "seatNo": "7,8,0000000001"}', data-status='0', data-id='7,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"24", "rowId": "4", "columnId": "24", "type": "N", "seatNo": "7,7,0000000001"}', data-status='0', data-id='7,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"25", "rowId": "4", "columnId": "25", "type": "N", "seatNo": "7,6,0000000001"}', data-status='0', data-id='7,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"26", "rowId": "4", "columnId": "26", "type": "N", "seatNo": "7,5,0000000001"}', data-status='0', data-id='7,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"27", "rowId": "4", "columnId": "27", "type": "N", "seatNo": "7,4,0000000001"}', data-status='0', data-id='7,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"28", "rowId": "4", "columnId": "28", "type": "N", "seatNo": "7,3,0000000001"}', data-status='0', data-id='7,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"30", "rowId": "4", "columnId": "29", "type": "N", "seatNo": "7,1,0000000001"}', data-status='0', data-id='7,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"3", "column":"31", "rowId": "4", "columnId": "30", "type": "N", "seatNo": "7,0,0000000001"}', data-status='0', data-id='7,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 4排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"1", "rowId": "5", "columnId": "1", "type": "N", "seatNo": "6,30,0000000001"}', data-status='0', data-id='6,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"2", "rowId": "5", "columnId": "2", "type": "N", "seatNo": "6,29,0000000001"}', data-status='0', data-id='6,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"3", "rowId": "5", "columnId": "3", "type": "N", "seatNo": "6,28,0000000001"}', data-status='0', data-id='6,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"4", "rowId": "5", "columnId": "4", "type": "N", "seatNo": "6,27,0000000001"}', data-status='0', data-id='6,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"5", "rowId": "5", "columnId": "5", "type": "N", "seatNo": "6,26,0000000001"}', data-status='0', data-id='6,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"6", "rowId": "5", "columnId": "6", "type": "N", "seatNo": "6,25,0000000001"}', data-status='0', data-id='6,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"7", "rowId": "5", "columnId": "7", "type": "N", "seatNo": "6,24,0000000001"}', data-status='0', data-id='6,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"8", "rowId": "5", "columnId": "8", "type": "N", "seatNo": "6,23,0000000001"}', data-status='0', data-id='6,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"9", "rowId": "5", "columnId": "9", "type": "N", "seatNo": "6,22,0000000001"}', data-status='0', data-id='6,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"10", "rowId": "5", "columnId": "10", "type": "N", "seatNo": "6,21,0000000001"}', data-status='0', data-id='6,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"11", "rowId": "5", "columnId": "11", "type": "N", "seatNo": "6,20,0000000001"}', data-status='0', data-id='6,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"12", "rowId": "5", "columnId": "12", "type": "N", "seatNo": "6,19,0000000001"}', data-status='0', data-id='6,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"13", "rowId": "5", "columnId": "13", "type": "N", "seatNo": "6,18,0000000001"}', data-status='0', data-id='6,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"14", "rowId": "5", "columnId": "14", "type": "N", "seatNo": "6,17,0000000001"}', data-status='0', data-id='6,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"15", "rowId": "5", "columnId": "15", "type": "N", "seatNo": "6,16,0000000001"}', data-status='0', data-id='6,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"16", "rowId": "5", "columnId": "16", "type": "N", "seatNo": "6,15,0000000001"}', data-status='0', data-id='6,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"17", "rowId": "5", "columnId": "17", "type": "N", "seatNo": "6,14,0000000001"}', data-status='0', data-id='6,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"18", "rowId": "5", "columnId": "18", "type": "N", "seatNo": "6,13,0000000001"}', data-status='0', data-id='6,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"19", "rowId": "5", "columnId": "19", "type": "N", "seatNo": "6,12,0000000001"}', data-status='0', data-id='6,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"20", "rowId": "5", "columnId": "20", "type": "N", "seatNo": "6,11,0000000001"}', data-status='0', data-id='6,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"21", "rowId": "5", "columnId": "21", "type": "N", "seatNo": "6,10,0000000001"}', data-status='0', data-id='6,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"22", "rowId": "5", "columnId": "22", "type": "N", "seatNo": "6,9,0000000001"}', data-status='0', data-id='6,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"23", "rowId": "5", "columnId": "23", "type": "N", "seatNo": "6,8,0000000001"}', data-status='0', data-id='6,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"24", "rowId": "5", "columnId": "24", "type": "N", "seatNo": "6,7,0000000001"}', data-status='0', data-id='6,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"25", "rowId": "5", "columnId": "25", "type": "N", "seatNo": "6,6,0000000001"}', data-status='0', data-id='6,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"26", "rowId": "5", "columnId": "26", "type": "N", "seatNo": "6,5,0000000001"}', data-status='0', data-id='6,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"27", "rowId": "5", "columnId": "27", "type": "N", "seatNo": "6,4,0000000001"}', data-status='0', data-id='6,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"28", "rowId": "5", "columnId": "28", "type": "N", "seatNo": "6,3,0000000001"}', data-status='0', data-id='6,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"30", "rowId": "5", "columnId": "29", "type": "N", "seatNo": "6,1,0000000001"}', data-status='0', data-id='6,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"4", "column":"31", "rowId": "5", "columnId": "30", "type": "N", "seatNo": "6,0,0000000001"}', data-status='0', data-id='6,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 5排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"1", "rowId": "6", "columnId": "1", "type": "N", "seatNo": "5,30,0000000001"}', data-status='0', data-id='5,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"2", "rowId": "6", "columnId": "2", "type": "N", "seatNo": "5,29,0000000001"}', data-status='0', data-id='5,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"3", "rowId": "6", "columnId": "3", "type": "N", "seatNo": "5,28,0000000001"}', data-status='0', data-id='5,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"4", "rowId": "6", "columnId": "4", "type": "N", "seatNo": "5,27,0000000001"}', data-status='0', data-id='5,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"5", "rowId": "6", "columnId": "5", "type": "N", "seatNo": "5,26,0000000001"}', data-status='0', data-id='5,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"6", "rowId": "6", "columnId": "6", "type": "N", "seatNo": "5,25,0000000001"}', data-status='0', data-id='5,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"7", "rowId": "6", "columnId": "7", "type": "N", "seatNo": "5,24,0000000001"}', data-status='0', data-id='5,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"8", "rowId": "6", "columnId": "8", "type": "N", "seatNo": "5,23,0000000001"}', data-status='0', data-id='5,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"9", "rowId": "6", "columnId": "9", "type": "N", "seatNo": "5,22,0000000001"}', data-status='0', data-id='5,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"10", "rowId": "6", "columnId": "10", "type": "N", "seatNo": "5,21,0000000001"}', data-status='0', data-id='5,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"11", "rowId": "6", "columnId": "11", "type": "N", "seatNo": "5,20,0000000001"}', data-status='0', data-id='5,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"12", "rowId": "6", "columnId": "12", "type": "N", "seatNo": "5,19,0000000001"}', data-status='0', data-id='5,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"13", "rowId": "6", "columnId": "13", "type": "N", "seatNo": "5,18,0000000001"}', data-status='0', data-id='5,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"14", "rowId": "6", "columnId": "14", "type": "N", "seatNo": "5,17,0000000001"}', data-status='0', data-id='5,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"15", "rowId": "6", "columnId": "15", "type": "N", "seatNo": "5,16,0000000001"}', data-status='0', data-id='5,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"16", "rowId": "6", "columnId": "16", "type": "N", "seatNo": "5,15,0000000001"}', data-status='0', data-id='5,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"17", "rowId": "6", "columnId": "17", "type": "N", "seatNo": "5,14,0000000001"}', data-status='0', data-id='5,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"18", "rowId": "6", "columnId": "18", "type": "N", "seatNo": "5,13,0000000001"}', data-status='0', data-id='5,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"19", "rowId": "6", "columnId": "19", "type": "N", "seatNo": "5,12,0000000001"}', data-status='0', data-id='5,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"20", "rowId": "6", "columnId": "20", "type": "N", "seatNo": "5,11,0000000001"}', data-status='0', data-id='5,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"21", "rowId": "6", "columnId": "21", "type": "N", "seatNo": "5,10,0000000001"}', data-status='0', data-id='5,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"22", "rowId": "6", "columnId": "22", "type": "N", "seatNo": "5,9,0000000001"}', data-status='0', data-id='5,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"23", "rowId": "6", "columnId": "23", "type": "N", "seatNo": "5,8,0000000001"}', data-status='0', data-id='5,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"24", "rowId": "6", "columnId": "24", "type": "N", "seatNo": "5,7,0000000001"}', data-status='0', data-id='5,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"25", "rowId": "6", "columnId": "25", "type": "N", "seatNo": "5,6,0000000001"}', data-status='0', data-id='5,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"26", "rowId": "6", "columnId": "26", "type": "N", "seatNo": "5,5,0000000001"}', data-status='0', data-id='5,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"27", "rowId": "6", "columnId": "27", "type": "N", "seatNo": "5,4,0000000001"}', data-status='0', data-id='5,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"28", "rowId": "6", "columnId": "28", "type": "N", "seatNo": "5,3,0000000001"}', data-status='0', data-id='5,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"30", "rowId": "6", "columnId": "29", "type": "N", "seatNo": "5,1,0000000001"}', data-status='0', data-id='5,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"5", "column":"31", "rowId": "6", "columnId": "30", "type": "N", "seatNo": "5,0,0000000001"}', data-status='0', data-id='5,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 6排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"1", "rowId": "7", "columnId": "1", "type": "N", "seatNo": "4,30,0000000001"}', data-status='0', data-id='4,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"2", "rowId": "7", "columnId": "2", "type": "N", "seatNo": "4,29,0000000001"}', data-status='0', data-id='4,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"3", "rowId": "7", "columnId": "3", "type": "N", "seatNo": "4,28,0000000001"}', data-status='0', data-id='4,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"4", "rowId": "7", "columnId": "4", "type": "N", "seatNo": "4,27,0000000001"}', data-status='0', data-id='4,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"5", "rowId": "7", "columnId": "5", "type": "N", "seatNo": "4,26,0000000001"}', data-status='0', data-id='4,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"6", "rowId": "7", "columnId": "6", "type": "N", "seatNo": "4,25,0000000001"}', data-status='0', data-id='4,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"7", "rowId": "7", "columnId": "7", "type": "N", "seatNo": "4,24,0000000001"}', data-status='0', data-id='4,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"8", "rowId": "7", "columnId": "8", "type": "N", "seatNo": "4,23,0000000001"}', data-status='0', data-id='4,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"9", "rowId": "7", "columnId": "9", "type": "N", "seatNo": "4,22,0000000001"}', data-status='0', data-id='4,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"10", "rowId": "7", "columnId": "10", "type": "N", "seatNo": "4,21,0000000001"}', data-status='0', data-id='4,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"11", "rowId": "7", "columnId": "11", "type": "N", "seatNo": "4,20,0000000001"}', data-status='0', data-id='4,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"12", "rowId": "7", "columnId": "12", "type": "N", "seatNo": "4,19,0000000001"}', data-status='0', data-id='4,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"13", "rowId": "7", "columnId": "13", "type": "N", "seatNo": "4,18,0000000001"}', data-status='0', data-id='4,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"14", "rowId": "7", "columnId": "14", "type": "N", "seatNo": "4,17,0000000001"}', data-status='0', data-id='4,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 14座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"15", "rowId": "7", "columnId": "15", "type": "N", "seatNo": "4,16,0000000001"}', data-status='0', data-id='4,16,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 15座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"16", "rowId": "7", "columnId": "16", "type": "N", "seatNo": "4,15,0000000001"}', data-status='0', data-id='4,15,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 16座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"17", "rowId": "7", "columnId": "17", "type": "N", "seatNo": "4,14,0000000001"}', data-status='0', data-id='4,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"18", "rowId": "7", "columnId": "18", "type": "N", "seatNo": "4,13,0000000001"}', data-status='0', data-id='4,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"19", "rowId": "7", "columnId": "19", "type": "N", "seatNo": "4,12,0000000001"}', data-status='0', data-id='4,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"20", "rowId": "7", "columnId": "20", "type": "N", "seatNo": "4,11,0000000001"}', data-status='0', data-id='4,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"21", "rowId": "7", "columnId": "21", "type": "N", "seatNo": "4,10,0000000001"}', data-status='0', data-id='4,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"22", "rowId": "7", "columnId": "22", "type": "N", "seatNo": "4,9,0000000001"}', data-status='0', data-id='4,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"23", "rowId": "7", "columnId": "23", "type": "N", "seatNo": "4,8,0000000001"}', data-status='0', data-id='4,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"24", "rowId": "7", "columnId": "24", "type": "N", "seatNo": "4,7,0000000001"}', data-status='0', data-id='4,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"25", "rowId": "7", "columnId": "25", "type": "N", "seatNo": "4,6,0000000001"}', data-status='0', data-id='4,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"26", "rowId": "7", "columnId": "26", "type": "N", "seatNo": "4,5,0000000001"}', data-status='0', data-id='4,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"27", "rowId": "7", "columnId": "27", "type": "N", "seatNo": "4,4,0000000001"}', data-status='0', data-id='4,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"28", "rowId": "7", "columnId": "28", "type": "N", "seatNo": "4,3,0000000001"}', data-status='0', data-id='4,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 28座
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"30", "rowId": "7", "columnId": "29", "type": "N", "seatNo": "4,1,0000000001"}', data-status='0', data-id='4,1,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 29座
                .wrap(data-love='0', data-info='{"index":"0","row":"6", "column":"31", "rowId": "7", "columnId": "30", "type": "N", "seatNo": "4,0,0000000001"}', data-status='0', data-id='4,0,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 7排
                      div 30座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"1", "rowId": "8", "columnId": "1", "type": "N", "seatNo": "3,30,0000000001"}', data-status='0', data-id='3,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"2", "rowId": "8", "columnId": "2", "type": "N", "seatNo": "3,29,0000000001"}', data-status='0', data-id='3,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"3", "rowId": "8", "columnId": "3", "type": "N", "seatNo": "3,28,0000000001"}', data-status='0', data-id='3,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"4", "rowId": "8", "columnId": "4", "type": "N", "seatNo": "3,27,0000000001"}', data-status='0', data-id='3,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"5", "rowId": "8", "columnId": "5", "type": "N", "seatNo": "3,26,0000000001"}', data-status='0', data-id='3,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"6", "rowId": "8", "columnId": "6", "type": "N", "seatNo": "3,25,0000000001"}', data-status='0', data-id='3,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"7", "rowId": "8", "columnId": "7", "type": "N", "seatNo": "3,24,0000000001"}', data-status='0', data-id='3,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"8", "rowId": "8", "columnId": "8", "type": "N", "seatNo": "3,23,0000000001"}', data-status='0', data-id='3,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"9", "rowId": "8", "columnId": "9", "type": "N", "seatNo": "3,22,0000000001"}', data-status='0', data-id='3,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"10", "rowId": "8", "columnId": "10", "type": "N", "seatNo": "3,21,0000000001"}', data-status='0', data-id='3,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"11", "rowId": "8", "columnId": "11", "type": "N", "seatNo": "3,20,0000000001"}', data-status='0', data-id='3,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"12", "rowId": "8", "columnId": "12", "type": "N", "seatNo": "3,19,0000000001"}', data-status='0', data-id='3,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"13", "rowId": "8", "columnId": "13", "type": "N", "seatNo": "3,18,0000000001"}', data-status='0', data-id='3,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"14", "rowId": "8", "columnId": "14", "type": "N", "seatNo": "3,17,0000000001"}', data-status='0', data-id='3,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 14座
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"19", "rowId": "8", "columnId": "19", "type": "N", "seatNo": "3,12,0000000001"}', data-status='0', data-id='3,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"20", "rowId": "8", "columnId": "20", "type": "N", "seatNo": "3,11,0000000001"}', data-status='0', data-id='3,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"21", "rowId": "8", "columnId": "21", "type": "N", "seatNo": "3,10,0000000001"}', data-status='0', data-id='3,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"22", "rowId": "8", "columnId": "22", "type": "N", "seatNo": "3,9,0000000001"}', data-status='0', data-id='3,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"23", "rowId": "8", "columnId": "23", "type": "N", "seatNo": "3,8,0000000001"}', data-status='0', data-id='3,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"24", "rowId": "8", "columnId": "24", "type": "N", "seatNo": "3,7,0000000001"}', data-status='0', data-id='3,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"25", "rowId": "8", "columnId": "25", "type": "N", "seatNo": "3,6,0000000001"}', data-status='0', data-id='3,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"26", "rowId": "8", "columnId": "26", "type": "N", "seatNo": "3,5,0000000001"}', data-status='0', data-id='3,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"27", "rowId": "8", "columnId": "27", "type": "N", "seatNo": "3,4,0000000001"}', data-status='0', data-id='3,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"7", "column":"28", "rowId": "8", "columnId": "28", "type": "N", "seatNo": "3,3,0000000001"}', data-status='0', data-id='3,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 8排
                      div 28座
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"1", "rowId": "9", "columnId": "1", "type": "N", "seatNo": "2,30,0000000001"}', data-status='0', data-id='2,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"2", "rowId": "9", "columnId": "2", "type": "N", "seatNo": "2,29,0000000001"}', data-status='0', data-id='2,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"3", "rowId": "9", "columnId": "3", "type": "N", "seatNo": "2,28,0000000001"}', data-status='0', data-id='2,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"4", "rowId": "9", "columnId": "4", "type": "N", "seatNo": "2,27,0000000001"}', data-status='0', data-id='2,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"5", "rowId": "9", "columnId": "5", "type": "N", "seatNo": "2,26,0000000001"}', data-status='0', data-id='2,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"6", "rowId": "9", "columnId": "6", "type": "N", "seatNo": "2,25,0000000001"}', data-status='0', data-id='2,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"7", "rowId": "9", "columnId": "7", "type": "N", "seatNo": "2,24,0000000001"}', data-status='0', data-id='2,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"8", "rowId": "9", "columnId": "8", "type": "N", "seatNo": "2,23,0000000001"}', data-status='0', data-id='2,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"9", "rowId": "9", "columnId": "9", "type": "N", "seatNo": "2,22,0000000001"}', data-status='0', data-id='2,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"10", "rowId": "9", "columnId": "10", "type": "N", "seatNo": "2,21,0000000001"}', data-status='0', data-id='2,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"11", "rowId": "9", "columnId": "11", "type": "N", "seatNo": "2,20,0000000001"}', data-status='0', data-id='2,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"12", "rowId": "9", "columnId": "12", "type": "N", "seatNo": "2,19,0000000001"}', data-status='0', data-id='2,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"13", "rowId": "9", "columnId": "13", "type": "N", "seatNo": "2,18,0000000001"}', data-status='0', data-id='2,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 13座
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"19", "rowId": "9", "columnId": "19", "type": "N", "seatNo": "2,12,0000000001"}', data-status='0', data-id='2,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"20", "rowId": "9", "columnId": "20", "type": "N", "seatNo": "2,11,0000000001"}', data-status='0', data-id='2,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"21", "rowId": "9", "columnId": "21", "type": "N", "seatNo": "2,10,0000000001"}', data-status='0', data-id='2,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"22", "rowId": "9", "columnId": "22", "type": "N", "seatNo": "2,9,0000000001"}', data-status='0', data-id='2,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"23", "rowId": "9", "columnId": "23", "type": "N", "seatNo": "2,8,0000000001"}', data-status='0', data-id='2,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"24", "rowId": "9", "columnId": "24", "type": "N", "seatNo": "2,7,0000000001"}', data-status='0', data-id='2,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"25", "rowId": "9", "columnId": "25", "type": "N", "seatNo": "2,6,0000000001"}', data-status='0', data-id='2,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"8", "column":"26", "rowId": "9", "columnId": "26", "type": "N", "seatNo": "2,5,0000000001"}', data-status='0', data-id='2,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 9排
                      div 26座
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"1", "rowId": "10", "columnId": "1", "type": "N", "seatNo": "1,30,0000000001"}', data-status='0', data-id='1,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"2", "rowId": "10", "columnId": "2", "type": "N", "seatNo": "1,29,0000000001"}', data-status='0', data-id='1,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"3", "rowId": "10", "columnId": "3", "type": "N", "seatNo": "1,28,0000000001"}', data-status='0', data-id='1,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"4", "rowId": "10", "columnId": "4", "type": "N", "seatNo": "1,27,0000000001"}', data-status='0', data-id='1,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"5", "rowId": "10", "columnId": "5", "type": "N", "seatNo": "1,26,0000000001"}', data-status='0', data-id='1,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"6", "rowId": "10", "columnId": "6", "type": "N", "seatNo": "1,25,0000000001"}', data-status='0', data-id='1,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"7", "rowId": "10", "columnId": "7", "type": "N", "seatNo": "1,24,0000000001"}', data-status='0', data-id='1,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"8", "rowId": "10", "columnId": "8", "type": "N", "seatNo": "1,23,0000000001"}', data-status='0', data-id='1,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"9", "rowId": "10", "columnId": "9", "type": "N", "seatNo": "1,22,0000000001"}', data-status='0', data-id='1,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"10", "rowId": "10", "columnId": "10", "type": "N", "seatNo": "1,21,0000000001"}', data-status='0', data-id='1,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"11", "rowId": "10", "columnId": "11", "type": "N", "seatNo": "1,20,0000000001"}', data-status='0', data-id='1,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"12", "rowId": "10", "columnId": "12", "type": "N", "seatNo": "1,19,0000000001"}', data-status='0', data-id='1,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"13", "rowId": "10", "columnId": "13", "type": "N", "seatNo": "1,18,0000000001"}', data-status='0', data-id='1,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"14", "rowId": "10", "columnId": "14", "type": "N", "seatNo": "1,17,0000000001"}', data-status='0', data-id='1,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 14座
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"17", "rowId": "10", "columnId": "17", "type": "N", "seatNo": "1,14,0000000001"}', data-status='0', data-id='1,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"18", "rowId": "10", "columnId": "18", "type": "N", "seatNo": "1,13,0000000001"}', data-status='0', data-id='1,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"19", "rowId": "10", "columnId": "19", "type": "N", "seatNo": "1,12,0000000001"}', data-status='0', data-id='1,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"20", "rowId": "10", "columnId": "20", "type": "N", "seatNo": "1,11,0000000001"}', data-status='0', data-id='1,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"21", "rowId": "10", "columnId": "21", "type": "N", "seatNo": "1,10,0000000001"}', data-status='0', data-id='1,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"22", "rowId": "10", "columnId": "22", "type": "N", "seatNo": "1,9,0000000001"}', data-status='0', data-id='1,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"23", "rowId": "10", "columnId": "23", "type": "N", "seatNo": "1,8,0000000001"}', data-status='0', data-id='1,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"24", "rowId": "10", "columnId": "24", "type": "N", "seatNo": "1,7,0000000001"}', data-status='0', data-id='1,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"25", "rowId": "10", "columnId": "25", "type": "N", "seatNo": "1,6,0000000001"}', data-status='0', data-id='1,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"26", "rowId": "10", "columnId": "26", "type": "N", "seatNo": "1,5,0000000001"}', data-status='0', data-id='1,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"27", "rowId": "10", "columnId": "27", "type": "N", "seatNo": "1,4,0000000001"}', data-status='0', data-id='1,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"9", "column":"28", "rowId": "10", "columnId": "28", "type": "N", "seatNo": "1,3,0000000001"}', data-status='0', data-id='1,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 10排
                      div 28座
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"1", "rowId": "11", "columnId": "1", "type": "N", "seatNo": "0,30,0000000001"}', data-status='0', data-id='0,30,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 1座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"2", "rowId": "11", "columnId": "2", "type": "N", "seatNo": "0,29,0000000001"}', data-status='0', data-id='0,29,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 2座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"3", "rowId": "11", "columnId": "3", "type": "N", "seatNo": "0,28,0000000001"}', data-status='0', data-id='0,28,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 3座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"4", "rowId": "11", "columnId": "4", "type": "N", "seatNo": "0,27,0000000001"}', data-status='0', data-id='0,27,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 4座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"5", "rowId": "11", "columnId": "5", "type": "N", "seatNo": "0,26,0000000001"}', data-status='0', data-id='0,26,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 5座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"6", "rowId": "11", "columnId": "6", "type": "N", "seatNo": "0,25,0000000001"}', data-status='0', data-id='0,25,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 6座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"7", "rowId": "11", "columnId": "7", "type": "N", "seatNo": "0,24,0000000001"}', data-status='0', data-id='0,24,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 7座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"8", "rowId": "11", "columnId": "8", "type": "N", "seatNo": "0,23,0000000001"}', data-status='0', data-id='0,23,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 8座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"9", "rowId": "11", "columnId": "9", "type": "N", "seatNo": "0,22,0000000001"}', data-status='0', data-id='0,22,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 9座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"10", "rowId": "11", "columnId": "10", "type": "N", "seatNo": "0,21,0000000001"}', data-status='0', data-id='0,21,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 10座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"11", "rowId": "11", "columnId": "11", "type": "N", "seatNo": "0,20,0000000001"}', data-status='0', data-id='0,20,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 11座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"12", "rowId": "11", "columnId": "12", "type": "N", "seatNo": "0,19,0000000001"}', data-status='0', data-id='0,19,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 12座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"13", "rowId": "11", "columnId": "13", "type": "N", "seatNo": "0,18,0000000001"}', data-status='0', data-id='0,18,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 13座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"14", "rowId": "11", "columnId": "14", "type": "N", "seatNo": "0,17,0000000001"}', data-status='0', data-id='0,17,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 14座
                .wrap(data-status='1')
                  .seat
                .wrap(data-status='1')
                  .seat
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"17", "rowId": "11", "columnId": "17", "type": "N", "seatNo": "0,14,0000000001"}', data-status='0', data-id='0,14,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 17座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"18", "rowId": "11", "columnId": "18", "type": "N", "seatNo": "0,13,0000000001"}', data-status='0', data-id='0,13,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 18座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"19", "rowId": "11", "columnId": "19", "type": "N", "seatNo": "0,12,0000000001"}', data-status='0', data-id='0,12,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 19座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"20", "rowId": "11", "columnId": "20", "type": "N", "seatNo": "0,11,0000000001"}', data-status='0', data-id='0,11,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 20座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"21", "rowId": "11", "columnId": "21", "type": "N", "seatNo": "0,10,0000000001"}', data-status='0', data-id='0,10,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 21座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"22", "rowId": "11", "columnId": "22", "type": "N", "seatNo": "0,9,0000000001"}', data-status='0', data-id='0,9,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 22座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"23", "rowId": "11", "columnId": "23", "type": "N", "seatNo": "0,8,0000000001"}', data-status='0', data-id='0,8,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 23座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"24", "rowId": "11", "columnId": "24", "type": "N", "seatNo": "0,7,0000000001"}', data-status='0', data-id='0,7,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 24座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"25", "rowId": "11", "columnId": "25", "type": "N", "seatNo": "0,6,0000000001"}', data-status='0', data-id='0,6,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 25座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"26", "rowId": "11", "columnId": "26", "type": "N", "seatNo": "0,5,0000000001"}', data-status='0', data-id='0,5,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 26座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"27", "rowId": "11", "columnId": "27", "type": "N", "seatNo": "0,4,0000000001"}', data-status='0', data-id='0,4,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 27座
                .wrap(data-love='0', data-info='{"index":"0","row":"10", "column":"28", "rowId": "11", "columnId": "28", "type": "N", "seatNo": "0,3,0000000001"}', data-status='0', data-id='0,3,0000000001', data-bid='dp_wx_seat_select')
                  .seat
                    .name
                      div 11排
                      div 28座
                .wrap
                  .seat
                .wrap
                  .seat
                .wrap
                  .seat
              .mew-info(style='transform: translate3d(0px, 0px, 0px) scale(1, 1) rotate3d(0, 0, 0, 0deg);')
                img(src='data:image/png;base64,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')
        .buy-block(data-show='recommend')
          .cinema-info
            .seat-type-info
              span.text-middle
                span.c.icon
                span.text 可选
              span.text-middle
                span.u.icon
                span.text 已选
              span.text-middle
                span.s.icon
                span.text 已售
              span.text-middle
                span.l.icon
                span.text 情侣座
          .recommend-price-block
            .recommend-block
              .title 推荐座位
              .recommend-list.grid-4
                .wrap(data-bid='dp_wx_seat_recommend')
                  .button(data-desc='{"img":"http://p0.meituan.net/movie/4d5558c36804180ca9a2355c2f16d2b05701957.png","remind":"赚到了，后排看IMAX体验更棒耶！"}', data-obj='[{"columnId":"16","rowId":"7","rowNum":6,"sectionId":"1"}]') 1人
                .wrap(data-bid='dp_wx_seat_recommend')
                  .button(data-desc='{"img":"http://p0.meituan.net/movie/4d5558c36804180ca9a2355c2f16d2b05701957.png","remind":"赚到了，后排看IMAX体验更棒耶！"}', data-obj='[{"columnId":"16","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"17","rowId":"7","rowNum":6,"sectionId":"1"}]') 2人
                .wrap(data-bid='dp_wx_seat_recommend')
                  .button(data-desc='{"img":"http://p0.meituan.net/movie/4d5558c36804180ca9a2355c2f16d2b05701957.png","remind":"赚到了，后排看IMAX体验更棒耶！"}', data-obj='[{"columnId":"15","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"16","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"17","rowId":"7","rowNum":6,"sectionId":"1"}]') 3人
                .wrap(data-bid='dp_wx_seat_recommend')
                  .button(data-desc='{"img":"http://p0.meituan.net/movie/4d5558c36804180ca9a2355c2f16d2b05701957.png","remind":"赚到了，后排看IMAX体验更棒耶！"}', data-obj='[{"columnId":"15","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"16","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"17","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"18","rowId":"7","rowNum":6,"sectionId":"1"}]') 4人
                .wrap(data-bid='dp_wx_seat_recommend')
                  .button(data-desc='{"img":"http://p0.meituan.net/movie/4d5558c36804180ca9a2355c2f16d2b05701957.png","remind":"赚到了，后排看IMAX体验更棒耶！"}', data-obj='[{"columnId":"14","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"15","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"16","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"17","rowId":"7","rowNum":6,"sectionId":"1"},{"columnId":"18","rowId":"7","rowNum":6,"sectionId":"1"}]') 5人
          .price-block(data-obj='{"seatsPrice":{"1":{"desc":[{"activity":"","price":"64"}],"totalPrice":"64"},"2":{"desc":[{"activity":"","price":"64"},{"activity":"","price":"64"}],"totalPrice":"128"},"3":{"desc":[{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"}],"totalPrice":"192"},"4":{"desc":[{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"}],"totalPrice":"256"},"5":{"desc":[{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"}],"totalPrice":"320"},"6":{"desc":[{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"},{"activity":"","price":"64"}],"totalPrice":"384"}},"seatsPriceDetail":{"1":{"detail":[],"display":false,"originPrice":"64"},"2":{"detail":[],"display":false,"originPrice":"64"},"3":{"detail":[],"display":false,"originPrice":"64"},"4":{"detail":[],"display":false,"originPrice":"64"},"5":{"detail":[],"display":false,"originPrice":"64"},"6":{"detail":[],"display":false,"originPrice":"64"}}}')
</template>

<script>
import Layout from "@/components/Layout";

/*
function(t, e, n) {
		(function(i) {
			"use strict";

			function a() {
                p = i(".seat-block .select-block"),
                    h = i(".select-block .hall-name-wrapper"),
                    u = i(".select-block .row-nav"),
                    m = i(".select-block .seats-block"),
                    f = i(".select-block .mew-info"),
                    v = i(".seats-wrap .wrap .seat"),
                    "mmweb" === window.channelName && f.hide(),
                    _ = p.width(),
                    g = p.height(),
                    b = m.width(),
                    w = m.height(),
                    y = u.eq(0).width(),
                    T = (_ - b) / 2,
                    E = (g - w) / 2,
                    A = function () {
					var t = b > w ? _ / b : g / w;
					return t * w > g && (t = g / w), t
                    }(),
                    A = A > 1 ? 1 : A, A *= .8,
                    A = A <  F? F : A,
                    I = T,
                    x = E,
                    C = A,
                    O || (O = new L["default"](m[0])),
                    m.data("transformer", O),
                    k || (k = new L["default"](u[0])),
                    u.data("transformer", k),
                    S || (S = new L["default"](h[0])),
                    h.data("transformer", S),
                    D || (D = new L["default"](f[0])),
                    f.data("transformer", D),
                    s(),
                    o()
			}
			function s() {
				M = {
					translateObj: {
						x: T,
						y: E,
						z: 0
					},
					scale: A
                },
                    i.extend(!0, O.transform, M),
                    O.update(),
                    i.extend(!0, k.transform, M),
                    k.transform.translateObj.x = -y * (1 - A) / 2,
                    k.update(),
                    i.extend(!1, D.transform, M),
                    D.update(),
                    i.extend(!0, S.transform, M);
				var t = b / 2 + T - h.width() / 2;
                i(".m-line").length && "none" !== i(".m-line").css("transform") && A > .8 && (t -= 23),
                    S.transform.translateObj.x = t,
                    S.transform.translateObj.y = 0,
                    S.transform.scale = 1,
                    S.update(),
                    l()
			}
			function o() {
				var t = new Hammer(m[0], {});
				t.get("pinch").set({
					enable: !0
				}), t.on("panstart swipestart pinchstart", function(t) {
					u.removeClass("animate"), h.removeClass("animate"), m.removeClass("animate")
				}), t.on("panend swipestart pinchend", function(t) {
					u.addClass("animate"), h.addClass("animate"), m.addClass("animate"), r()
				}), t.on("panstart", function(t) {
					j = T, P = E
				}), t.on("panmove", function(t) {
					T = j + t.deltaX, E = P + t.deltaY, _ > b * A ? T = I : (T < X.right && (T = X.right), T > X.left && (T = X.left)), g > w * A ? E = x : (E < X.bottom && (E = X.bottom), E > X.top && (E = X.top)), s()
				}), t.on("pinchstart", function(t) {
					R = A
				}), t.on("pinchmove", function(t) {
					var e = R * t.scale;
					if (e > H || e < F) return void t.preventDefault();
					A = e, s()
				})
			}
			function r() {
				var t = !1;
				m.width() * A < _ && (T = I, t = !0), m.height() * A < g && (E = x, t = !0), t && s()
			}
			function l() {
				X = {
					left: b / 2 * (A - 1) + 40,
					right: _ - b / 2 * (1 + A) - 40,
					top: w / 2 * (A - 1) + 40,
					bottom: g - w / 2 * (1 + A) - 40
				}, T < X.right && (T = X.right), T > X.left && (T = X.left), E < X.bottom && (E = X.bottom), E > X.top && (E = X.top)
			}
			function c() {
				if (!(C >= .8)) {
					var t = this,
						e = t.outerWidth() * A,
						n = t.outerHeight() * A,
						a = t.data("info"),
						o = function() {
							var e = t.parent();
							if (0 === e.siblings(".seats-wrap").length) return 0;
							var n = parseInt(a.index, 10);
							if (0 === n) return 0;
							var s = 0;
							return e.siblings(".seats-wrap").each(function(t) {
								t < n && (s += i(this).height())
							}), s
						}(),
						r = function() {
							return {
								left: (a.column - 1) * e,
								top: (a.row - 1) * n + o * A
							}
						}();
					_ = i(".seat-block .select-block").width(), g = i(".seat-block .select-block").height();
					var c = (r.left + e / 2) / (m.width() * A) * b,
						d = (r.top + n / 2) / (m.height() * A) * w;
					T = _ / 2 - c, E = g / 2 - d, A = .9, l(), s()
				}
			}
			var d = n(63)["default"];
			Object.defineProperty(e, "__esModule", {
				value: !0
			}), e["default"] = a, n(762);
			var p, u, h, m, f, v, _, g, b, w, y, I, x, C, T, E, A, M, O, k, D, S, j, P, R, N = n(763),
				L = d(N),
				U = n(767),
				B = d(U),
				Y = n(769),
				H = .9,
				F = .4,
				X = {
					left: 0,
					right: 0,
					top: 0,
					bottom: 0
				},
				z = !0;
			i(".seat-block .select-block").on("click", '.seats-wrap .wrap[data-status="0"]', function(t) {
				var e = i(this),
					n = e.data("love"),
					a = constant.seatData.seat,
					s = a.doIconRain,
					o = a.iconRainTriggerMillis,
					r = a.iconRains;
				if (e.hasClass("active")) e.removeClass("active"), 1 == n ? e.next(".wrap").removeClass("active") : 2 == n && e.prev(".wrap").removeClass("active"), B["default"].unSelected();
				else {
					var l = i('.select-block .seats-wrap .wrap[data-status="0"].active').length;
					if (1 != n && 2 != n || l++, constant.discountLimit > 0 && l >= constant.discountLimit && z && l < constant.discountLimit + 1 && (Toast("褰撳墠浼樻儬娲诲姩闄愯喘" + constant.discountLimit + "寮犵エ"), z = !1), l >= constant.limit) return Toast("姣忔鏈€澶氬彲閫�" + constant.limit + "涓骇浣�"), !1;
					e.addClass("active"), 1 == n ? e.next(".wrap").addClass("active") : 2 == n && e.prev(".wrap").addClass("active"), B["default"].selected(), c.call(e)
				}(0, Y.startIconRain)(s, o, r, i('.select-block .seats-wrap .wrap[data-status="0"].active').length, !1)
			}), t.exports = e["default"]
		}).call(e, n(1))
	},

*/

export default {
  data: function() {
    return {
      hallData: {
        sections: [
          {
            cols: 31,
            rows: 10,
            seats: [
              {
                columns: [
                  { columnId: "1", seatNo: "9,30,0000000001", st: "N" },
                  { columnId: "2", seatNo: "9,29,0000000001", st: "N" },
                  { columnId: "3", seatNo: "9,28,0000000001", st: "N" },
                  { columnId: "4", seatNo: "9,27,0000000001", st: "N" },
                  { columnId: "5", seatNo: "9,26,0000000001", st: "N" },
                  { columnId: "6", seatNo: "9,25,0000000001", st: "N" },
                  { columnId: "7", seatNo: "9,24,0000000001", st: "N" },
                  { columnId: "8", seatNo: "9,23,0000000001", st: "N" },
                  { columnId: "9", seatNo: "9,22,0000000001", st: "N" },
                  { columnId: "10", seatNo: "9,21,0000000001", st: "N" },
                  { columnId: "11", seatNo: "9,20,0000000001", st: "N" },
                  { columnId: "12", seatNo: "9,19,0000000001", st: "N" },
                  { columnId: "13", seatNo: "9,18,0000000001", st: "N" },
                  { columnId: "14", seatNo: "9,17,0000000001", st: "N" },
                  { columnId: "15", seatNo: "9,16,0000000001", st: "N" },
                  { columnId: "16", seatNo: "9,15,0000000001", st: "N" },
                  { columnId: "17", seatNo: "9,14,0000000001", st: "N" },
                  { columnId: "18", seatNo: "9,13,0000000001", st: "N" },
                  { columnId: "19", seatNo: "9,12,0000000001", st: "N" },
                  { columnId: "20", seatNo: "9,11,0000000001", st: "N" },
                  { columnId: "21", seatNo: "9,10,0000000001", st: "N" },
                  { columnId: "22", seatNo: "9,9,0000000001", st: "N" },
                  { columnId: "23", seatNo: "9,8,0000000001", st: "N" },
                  { columnId: "24", seatNo: "9,7,0000000001", st: "N" },
                  { columnId: "25", seatNo: "9,6,0000000001", st: "N" },
                  { columnId: "26", seatNo: "9,5,0000000001", st: "N" },
                  { columnId: "27", seatNo: "9,4,0000000001", st: "N" },
                  { columnId: "28", seatNo: "9,3,0000000001", st: "N" },
                  { columnId: "", seatNo: "", st: "E" },
                  { columnId: "29", seatNo: "9,1,0000000001", st: "N" },
                  { columnId: "30", seatNo: "9,0,0000000001", st: "N" }
                ],
                rowId: "2",
                rowNum: 1
              }
            ],
            sectionId: "1",
            sectionName: "花城汇IMAX"
          }
        ]
      }
      // seatBlock: {
      //   seatWidth: 46, //座位宽46px
      //   maxSeatLength: 0,
      //   scale: 0.4, //初始是0.4，选中后0.9
      //   seatblockStyle:
      //     "width: 1426px; touch-action: none; user-select: none; -webkit-user-drag: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); transform: translate3d(-525.5px, 41.1095px, 0px) scale(0.4, 0.4) rotate3d(0, 0, 0, 0deg);",
      //   rowNavStyle:
      //     "transform: translate3d(-4.8px, 41.1095px, 0px) scale(0.4, 0.4) rotate3d(0, 0, 0, 0deg);",
      //   selectBlockStyle: "margin-top: 0.3rem; height: 562.234px;"
      // },
      // selectBlockStyle: null,
      // hallNameStyle: null,
      // rowNavStyle: null,
      // seatblockStyle: null
    };
  },
  created() {
    // var lengtharr = this.hallData.sections[0].seats.map(x => x.columns.length);
    // this.seatBlock.maxSeatLength = Math.max(...lengtharr);
    // console.log(this.seatBlock);
    // this.selectBlockStyle = {
    //   "margin-top": "0.3rem",
    //   height: "562.234px"
    // };
    // this.hallNameStyle = {
    //   transform:
    //     "translate3d(-50.2px, 0px, 0px) scale(1, 1) rotate3d(0, 0, 0, 0deg)"
    // };
    // this.rowNavStyle = {
    //   transform:
    //     "translate3d(-4.8px, 41.1095px, 0px) scale(0.4, 0.4) rotate3d(0, 0, 0, 0deg)"
    // };
    // this.seatblockStyle = {
    //   width: this.seatBlock.maxSeatLength * this.seatBlock.seatWidth + "px",
    //   "touch-action": "none",
    //   "user-select": "none",
    //   "-webkit-user-drag": "none",
    //   "-webkit-tap-highlight-color": "rgba(0, 0, 0, 0)",
    //   transform:
    //     "translate3d(-663.2px, 41.1095px, 0px) scale(0.4, 0.4) rotate3d(0, 0, 0, 0deg)"
    // };
  },
  mounted() {},
  methods: {},
  computed: {},
  components: {
    Layout
  },
  directives: {
    drag: {
      // 指令的定义
      inserted: function(el) {
        let odiv = el; //获取当前元素
        let p = document.querySelector(".seat-block .select-block");
        let h = document.querySelector(".select-block .hall-name-wrapper");
        let u = document.querySelector(".select-block .row-nav");
        let m = document.querySelector(".select-block .seats-block");
        let f = document.querySelector(".select-block .mew-info");
        let v = document.querySelector(".seats-wrap .wrap .seat");
        let line = document.querySelector(".m-line");
        let _ = p.clientWidth;
        let g = p.clientHeight;
        let b = m.scrollWidth;
        let w = m.scrollHeight;
        let y = u.children[0].clientWidth;
        let T = (_ - b) / 2; //x
        let E = (g - w) / 2; //y
        let F = 0.4;
        console.log(p, m, u);
        console.log({ _, g, b, w, y, T, E });
        var t = b > w ? _ / b : g / w;
        t * w > g && (t = g / w);
        var A = t;
        A = A > 1 ? 1 : A;
        A = A * 0.8;
        A = A < F ? F : A;
        var scale = A;
        console.log({ x: T, y: E, t, scale });

        var x2 = (-y * (1 - A)) / 2;
        var nameX = b / 2 + T - h.clientWidth / 2;
        //当计数列，则添加样式 -webkit-transform: translateX(-23px);transform: translateX(-23px);
        line &&
          "none" !== getComputedStyle(line)["transform"] &&
          A > 0.8 &&
          (nameX = nameX - 23);

        m.style.width = `1426px`;
        m.style.transform = `translate3d(${T}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
        u.style.transform = `translate3d(${x2}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;

        h.style.transform = `translate3d(${nameX}px, 0px, 0px) scale(1, 1) rotate3d(0, 0, 0, 0deg)`;

        odiv.onmousedown = e => {
          //算出鼠标相对元素的位置
          let disX = e.clientX - T;
          let disY = e.clientY - E;

          console.log({ disX, disY });

          document.onmousemove = e => {
            //用鼠标的位置减去鼠标相对元素的位置，得到元素的位置
            T = e.clientX - disX;
            //E = e.clientY - disY;

            m.style.transform = `translate3d(${T}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
            u.style.transform = `transform: translate3d(-4.8px, -103.188px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;

            //移动当前元素
            // odiv.style.left = left + "px";
            // odiv.style.top = top + "px";
          };
          document.onmouseup = e => {
            document.onmousemove = null;
            document.onmouseup = null;
          };
        };
      }
    }
  }
};
</script>

<style scoped>
a {
  text-decoration: none;
}
.confirm_alert {
  width: 280px;
  background: #fff;
  border-radius: 10px;
  -webkit-border-radius: 10px;
  position: fixed;
  margin: auto;
  left: 50%;
  top: 50%;
  -webkit-transform: translateX(-50%) translateY(-50%);
  transform: translateX(-50%) translateY(-50%);
  border: 1px solid #efefef;
  text-align: center;
  z-index: 10000002;
}
.confirm_alert .alert_content {
  padding: 20px;
  border-bottom: 1px solid #efefef;
}
.confirm_alert .alert_buttons {
  font-size: 14px;
  height: 40px;
  line-height: 40px;
}
.confirm_alert a {
  color: #08c;
  float: left;
  width: 50%;
  height: 100%;
  box-sizing: border-box;
  -webkit-box-sizing: border-box;
}
.confirm_alert a.last {
  border-left: 1px solid #efefef;
}
.confirm_alert a.all {
  width: 100%;
}
</style>

<style scoped>
@import "../assets/css/hall-common.css";
</style>
<style scoped>
@import "../assets/css/hall-theme.css";
</style>
<style scoped>
@import "../assets/css/hall-seats.css";
</style>
