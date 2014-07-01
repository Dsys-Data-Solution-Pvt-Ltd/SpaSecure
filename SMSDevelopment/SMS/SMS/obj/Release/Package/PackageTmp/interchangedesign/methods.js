  <script type="text/javascript">
      function clearAll() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          //          var VID = seriesid.options[seriesid.selectedIndex].text;
          //alert((document.getElementById('<%=ddlseries.ClientID%>')).options[(document.getElementById('<%=ddlseries.ClientID%>')).selectedIndex].text);
          seriesid.selectedIndex = 0;
          // var VID =seriesid.options[seriesid.selectedIndex].value;

          document.getElementById('search1').value = "";
          document.getElementById('search2').value = ""; document.getElementById('search3').value = "";
          document.getElementById('search4').value = ""; document.getElementById('search5').value = "";
          document.getElementById('search6').value = ""; document.getElementById('search7').value = "";
          $('#message').text = "";
      }
      function FinalPro() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var VID = seriesid.options[seriesid.selectedIndex].text;
          $.ajax({
              type: "POST",
              url: "interauto.asmx/FinalPro",
              data: "{ 'pto': '" + VID + "','mg': '" + document.getElementById('search1').value + "', 'gr': '" + document.getElementById('search2').value + "','st':'" + document.getElementById('search3').value + "','aa':'" + document.getElementById('search4').value + "','os':'" + document.getElementById('search5').value + "','sf':'" + document.getElementById('search6').value + "','pl':'" + document.getElementById('search7').value + "'}",
              contentType: "application/json",
              async: false,
              success: function (data) {
                  $('#message').html(data.d);
              },
              error: function (result) {
                  alert("Error Occurred");
              }
          });
      }
      $(document).ready(function () {
          SearchText();
      });
      function SearchText() {
          $("#searchpto").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/GetAutoCompleteData",
                      data: "{'CategoryName':'" + document.getElementById('searchpto').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      $(document).ready(function () {
          //SearchTextmg();
      });
      function SearchText1() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 2; }
          if (mid == 2)
          { cid = 2; }
          $("#search1").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search1').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                          $('#message').html(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText2() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 13; }
          if (mid == 2)
          { cid = 13; }
          $("#search2").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search2').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText3() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 4; }
          if (mid == 2)
          { cid = 11; }
          $("#search3").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search3').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText4() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 5; }
          if (mid == 2)
          { cid = 12; }
          $("#search4").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search4').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText5() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 6; }
          if (mid == 2)
          { cid = 14; }
          $("#search5").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search5').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText6() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 15; }
          if (mid == 2)
          { cid = 15; }
          $("#search6").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search6').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      function SearchText7() {
          var seriesid = document.getElementById('<%=ddlseries.ClientID%>');
          var sid = seriesid.options[seriesid.selectedIndex].value;
          var manufid = document.getElementById('<%=ddlcompe.ClientID%>');
          var mid = manufid.selectedIndex;
          var cid = 0;
          if (mid == 1)
          { cid = 8; }
          if (mid == 2)
          { cid = 8; }
          $("#search7").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      url: "interauto.asmx/mg",
                      data: "{'cid':'" + cid + "','mid':'" + mid + "','sid':'" + sid + "','name':'" + document.getElementById('search7').value + "'}",
                      dataType: "json",
                      success: function (data) {
                          response(data.d);
                      },
                      error: function (result) {
                          alert("Error Occurred");
                      }
                  });
              }
          });
      }
      

 </script>